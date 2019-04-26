using System;
using System.Collections.Generic;
using System.Linq;
using ForgeModel;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;
using ForgeServiceDAL.Interfaces;

namespace ForgeServiceImplementList.Implementations
{
    public class IngredientServiceList : IIngredientService
    {
        private DataListSingleton source;

        public IngredientServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<IngredientViewModel> GetList()
        {
            List<IngredientViewModel> result = source.Ingredients.Select(rec => new IngredientViewModel
            {
                IngredientId = rec.IngredientId,
                IngredientName = rec.IngredientName
            }).ToList();
            return result;
        }

        public IngredientViewModel GetElement(int IngredientId)
        {
            Ingredient el = source.Ingredients.FirstOrDefault(rec => rec.IngredientId == IngredientId);
            if (el != null)
            {
                return new IngredientViewModel()
                {
                    IngredientId = el.IngredientId,
                    IngredientName = el.IngredientName
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(IngredientBindingModel model)
        {
            Ingredient element = source.Ingredients.FirstOrDefault(rec => rec.IngredientName ==
                                                                  model.IngredientName);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            int maxId = source.Ingredients.Count > 0 ? source.Ingredients.Max(rec => rec.IngredientId) : 0;
            source.Ingredients.Add(new Ingredient
            {
                IngredientId = maxId + 1,
                IngredientName = model.IngredientName
            });
        }

        public void UpdElement(IngredientBindingModel model)
        {
            Ingredient element = source.Ingredients.FirstOrDefault(rec => rec.IngredientName ==
                                                                  model.IngredientName && rec.IngredientId != model.IngredientId);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = source.Ingredients.FirstOrDefault(rec => rec.IngredientId == model.IngredientId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.IngredientName = model.IngredientName;
        }

        public void DelElement(int IngredientId)
        {
            Ingredient element = source.Ingredients.FirstOrDefault(rec => rec.IngredientId == IngredientId);
            if (element != null)
            {
                source.Ingredients.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
