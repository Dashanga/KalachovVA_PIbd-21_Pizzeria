using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgeModel;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;

namespace PizzeriaServiceImplementDB.Implementations
{
    public class PizzaServiceDb : IPizzaService
    {
        private AbstractDbContext context;
        public PizzaServiceDb(AbstractDbContext context)
        {
            this.context = context;
        }
        public List<PizzaViewModel> GetList()
        {
            List<PizzaViewModel> result = context.Pizzas.Select(rec => new
           PizzaViewModel
            {
                PizzaId = rec.PizzaId,
                PizzaName = rec.PizzaName,
                Cost = rec.Cost,
                PizzaIngredients = context.PizzaIngredients
                    .Where(recPC => recPC.PizzaId == rec.PizzaId)
                    .Select(recPC => new PizzaIngredientViewModel
                   {
                       PizzaIngredientId = recPC.PizzaIngredientId,
                       PizzaId = recPC.PizzaId,
                       IngredientId = recPC.IngredientId,
                       IngredientName = recPC.Ingredient.IngredientName,
                       PizzaIngredientCount = recPC.PizzaIngredientCount
                   })
                   .ToList()
            })
            .ToList();
            return result;
        }

        public PizzaViewModel GetElement(int id)
        {
            Pizza element = context.Pizzas.FirstOrDefault(rec => rec.PizzaId == id);
            if (element != null)
            {
                return new PizzaViewModel
            {
                PizzaId = element.PizzaId,
                PizzaName = element.PizzaName,
                Cost = element.Cost,
                PizzaIngredients = context.PizzaIngredients
                .Where(recPC => recPC.PizzaId == element.PizzaId)
                .Select(recPC => new PizzaIngredientViewModel
                 {
                     PizzaIngredientId = recPC.PizzaIngredientId,
                     PizzaId = recPC.PizzaId,
                     IngredientId = recPC.IngredientId,
                     IngredientName = recPC.Ingredient.IngredientName,
                     PizzaIngredientCount = recPC.PizzaIngredientCount
                 })
                .ToList()
              };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(PizzaBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                   Pizza element = context.Pizzas.FirstOrDefault(rec =>
                   rec.PizzaName == model.PizzaName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Pizza
                    {
                        PizzaName = model.PizzaName,
                        Cost = model.Cost
                    };
                    context.Pizzas.Add(element);
                    context.SaveChanges();
                    // убираем дубли по компонентам
                    var groupIngredients = model.PizzaIngredients
                    .GroupBy(rec => rec.IngredientId)
                    .Select(rec => new
                    {
                        IngredientId = rec.Key,
                        Count = rec.Sum(r => r.PizzaIngredientCount)
                    });
                    // добавляем компоненты
                    foreach (var groupIngredient in groupIngredients)
                    {
                        context.PizzaIngredients.Add(new PizzaIngredient
                        {
                            PizzaId = element.PizzaId,
                            IngredientId = groupIngredient.IngredientId,
                            PizzaIngredientCount = groupIngredient.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElement(PizzaBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                   Pizza element = context.Pizzas.FirstOrDefault(rec =>
                   rec.PizzaName == model.PizzaName && rec.PizzaId != model.PizzaId);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Pizzas.FirstOrDefault(rec => rec.PizzaId == model.PizzaId);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.PizzaName = model.PizzaName;
                    element.Cost = model.Cost;
                    context.SaveChanges();
                    // обновляем существуюущие компоненты
                    var compIds = model.PizzaIngredients.Select(rec =>
                   rec.IngredientId).Distinct();
                    var updateIngredients = context.PizzaIngredients.Where(rec =>
                   rec.PizzaId == model.PizzaId && compIds.Contains(rec.IngredientId));
                    foreach (var updateIngredient in updateIngredients)
                    {
                        updateIngredient.PizzaIngredientCount =
                        model.PizzaIngredients.FirstOrDefault(rec => rec.PizzaIngredientId == updateIngredient.PizzaIngredientId).PizzaIngredientCount;
                    }
                    context.SaveChanges();

                    context.PizzaIngredients.RemoveRange(context.PizzaIngredients.Where(rec =>
                    rec.PizzaId == model.PizzaId && !compIds.Contains(rec.IngredientId)));
                    context.SaveChanges();
                    // новые записи
                    var groupIngredients = model.PizzaIngredients
                   .Where(rec => rec.PizzaIngredientId == 0)
                   .GroupBy(rec => rec.IngredientId)
                    .Select(rec => new
                    {
                        IngredientId = rec.Key,
                        Count = rec.Sum(r => r.PizzaIngredientCount)
                    });
                    foreach (var groupIngredient in groupIngredients)
                    {
                        PizzaIngredient elementPC =
                       context.PizzaIngredients.FirstOrDefault(rec => rec.PizzaId == model.PizzaId &&
                       rec.IngredientId == groupIngredient.IngredientId);
                        if (elementPC != null)
                        {
                            elementPC.PizzaIngredientCount += groupIngredient.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.PizzaIngredients.Add(new PizzaIngredient
                            {
                                PizzaId = model.PizzaId,
                            IngredientId = groupIngredient.IngredientId,
                                PizzaIngredientCount = groupIngredient.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Pizza element = context.Pizzas.FirstOrDefault(rec => rec.PizzaId ==
                   id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.PizzaIngredients.RemoveRange(context.PizzaIngredients.Where(rec =>
                        rec.PizzaId == id));
                        context.Pizzas.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
