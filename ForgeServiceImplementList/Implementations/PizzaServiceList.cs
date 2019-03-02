using System;
using System.Collections.Generic;
using System.Linq;
using ForgeModel;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;
using ForgeServiceDAL.Interfaces;

namespace ForgeServiceImplementList.Implementations
{
    public class PizzaServiceList : IPizzaService
    {
        private DataListSingleton source;

        public PizzaServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<PizzaViewModel> GetList()
        {
            List<PizzaViewModel> result = source.Pizzas
                .Select(rec => new PizzaViewModel
                {
                    PizzaId = rec.PizzaId,
                    PizzaName = rec.PizzaName,
                    Cost = rec.Cost,
                    PizzaIngredients = source.PizzaIngredients
                        .Where(recPI => recPI.PizzaId == rec.PizzaId)
                        .Select(recPI => new PizzaIngredientViewModel
                        {
                            PizzaIngredientId = recPI.PizzaId,
                            PizzaId = recPI.PizzaId,
                            IngredientId = recPI.IngredientId,
                            IngredientName = source.Ingredients.FirstOrDefault(recI =>
                                recI.IngredientId == recPI.IngredientId)?.IngredientName,
                            PizzaIngredientCount = recPI.PizzaIngredientCount
                        })
                        .ToList()
                })
                .ToList();
            return result;
        }
        public PizzaViewModel GetElement(int id)
        {
            Pizza element = source.Pizzas.FirstOrDefault(rec => rec.PizzaId == id);
            if (element != null)
            {
                return new PizzaViewModel
                {
                    PizzaId = element.PizzaId,
                    PizzaName = element.PizzaName,
                    Cost = element.Cost,
                    PizzaIngredients = source.PizzaIngredients
                        .Where(recPI => recPI.PizzaId == element.PizzaId)
                        .Select(recPI => new PizzaIngredientViewModel
                        {
                            PizzaIngredientId = recPI.PizzaId,
                            PizzaId = recPI.PizzaId,
                            IngredientId = recPI.IngredientId,
                            IngredientName = source.Ingredients.FirstOrDefault(recI =>
                                recI.IngredientId == recPI.IngredientId)?.IngredientName,
                            PizzaIngredientCount = recPI.PizzaIngredientCount
                        })
                        .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(PizzaBindingModel model)
        {
            Pizza element = source.Pizzas.FirstOrDefault(rec => rec.PizzaName == model.PizzaName);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.Pizzas.Count > 0 ? source.Pizzas.Max(rec => rec.PizzaId) : 0;
            source.Pizzas.Add(new Pizza
            {
                PizzaId = maxId + 1,
                PizzaName = model.PizzaName,
                Cost = model.Cost
            });
            int maxPCId = source.PizzaIngredients.Count > 0 ?
                source.PizzaIngredients.Max(rec => rec.PizzaId) : 0;
            var groupIngredients = model.PizzaIngredients
                .GroupBy(rec => rec.IngredientId)
                .Select(rec => new
                {
                    IngredientId = rec.Key,
                    PizzaIngredientCount = rec.Sum(r => r.PizzaIngredientCount)
                });
            foreach (var groupIngredient in groupIngredients)
            {
                source.PizzaIngredients.Add(new PizzaIngredient
                {
                    PizzaIngredientId = ++maxPCId,
                    PizzaId = maxId + 1,
                    IngredientId = groupIngredient.IngredientId,
                    PizzaIngredientCount = groupIngredient.PizzaIngredientCount
                });
            }
        }

        public void UpdElement(PizzaBindingModel model)
        {
            Pizza element = source.Pizzas.FirstOrDefault(rec => rec.PizzaName ==
                                                         model.PizzaName && rec.PizzaId != model.PizzaId);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }

            element = source.Pizzas.FirstOrDefault(rec => rec.PizzaId == model.PizzaId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            element.PizzaName = model.PizzaName;
            element.Cost = model.Cost;
            int maxPCId = source.PizzaIngredients.Count > 0 ? source.PizzaIngredients.Max(rec => rec.PizzaId) : 0;
            // обновляем существуюущие компоненты
            var compIds = model.PizzaIngredients.Select(rec =>
                rec.IngredientId).Distinct();
            var updateIngredients = source.PizzaIngredients.Where(rec => rec.PizzaId ==
                                                                         model.PizzaId && compIds.Contains(rec.IngredientId));
            foreach (var updateIngredient in updateIngredients)
            {
                updateIngredient.PizzaIngredientCount = model.PizzaIngredients.FirstOrDefault(rec =>
                    rec.PizzaId == updateIngredient.PizzaId).PizzaIngredientCount;
            }
            source.PizzaIngredients.RemoveAll(rec => rec.PizzaId == model.PizzaId &&
                                                      !compIds.Contains(rec.IngredientId));
            // новые записи
            var groupIngredients = model.PizzaIngredients
                .Where(rec => rec.PizzaId == 0)
                .GroupBy(rec => rec.IngredientId)
                .Select(rec => new
                {
                    IngredientId = rec.Key,
                    PizzaIngredientCount = rec.Sum(r => r.PizzaIngredientCount)
                });
            foreach (var groupIngredient in groupIngredients)
            {
                PizzaIngredient elementPC = source.PizzaIngredients.FirstOrDefault(rec
                    => rec.PizzaId == model.PizzaId && rec.IngredientId == groupIngredient.IngredientId);
                if (elementPC != null)
                {
                    elementPC.PizzaIngredientCount += groupIngredient.PizzaIngredientCount;
                }
                else
                {
                    source.PizzaIngredients.Add(new PizzaIngredient
                    {
                        PizzaIngredientId = ++maxPCId,
                        PizzaId = model.PizzaId,
                        IngredientId = groupIngredient.IngredientId,
                        PizzaIngredientCount = groupIngredient.PizzaIngredientCount
                    });
                }
            }
        }


        public void DelElement(int id)
        {
            Pizza element = source.Pizzas.FirstOrDefault(rec => rec.PizzaId == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.PizzaIngredients.RemoveAll(rec => rec.PizzaId == id);
                source.Pizzas.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
