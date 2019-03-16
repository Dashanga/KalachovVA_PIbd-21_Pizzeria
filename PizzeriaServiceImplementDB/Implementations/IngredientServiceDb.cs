using System;
using System.Collections.Generic;
using System.Linq;
using ForgeModel;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;
using ForgeServiceDAL.Interfaces;
using PizzeriaServiceImplementDB;
using System.Data.Entity;


namespace ForgeServiceImplementList.Implementations
{
    public class IngredientServiceDb : IIngredientService
    {
        private AbstractDbContext context;

        public IngredientServiceDb(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<IngredientViewModel> GetList()
        {
            List<IngredientViewModel> result = context.Ingredients.Select(rec => new
                    IngredientViewModel
            {
                IngredientId = rec.IngredientId,
                IngredientName = rec.IngredientName
            })
                .ToList();
            return result;
        }
        public IngredientViewModel GetElement(int id)
        {
            Ingredient element = context.Ingredients.FirstOrDefault(rec => rec.IngredientId == id);
            if (element != null)
            {
                return new IngredientViewModel
                {
                    IngredientId = element.IngredientId,
                    IngredientName = element.IngredientName
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(IngredientBindingModel model)
        {
            Ingredient element = context.Ingredients.FirstOrDefault(rec => rec.IngredientName ==
                                                                   model.IngredientName);
            if (element != null)
            {
                throw new Exception("Уже есть ингредиент с таким названием");
            }
            context.Ingredients.Add(new Ingredient
            {
                IngredientName = model.IngredientName
            });
            context.SaveChanges();
        }
        public void UpdElement(IngredientBindingModel model)
        {
            Ingredient element = context.Ingredients.FirstOrDefault(rec => rec.IngredientName ==
                                                                   model.IngredientName && rec.IngredientId != model.IngredientId);
            if (element != null)
            {
                throw new Exception("Уже есть ингредиент с таким названием");
            }
            element = context.Ingredients.FirstOrDefault(rec => rec.IngredientId == model.IngredientId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.IngredientName = model.IngredientName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Ingredient element = context.Ingredients.FirstOrDefault(rec => rec.IngredientId == id);
            if (element != null)
            {
                context.Ingredients.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
