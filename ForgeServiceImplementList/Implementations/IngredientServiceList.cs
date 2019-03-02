using System;
using System.Collections.Generic;
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
            var result = new List<IngredientViewModel>();
            for (int i = 0; i < source.Ingredients.Count; ++i)
            {
                result.Add(new IngredientViewModel
                {
                    IngredientId = source.Ingredients[i].IngredientId,
                    IngredientName = source.Ingredients[i].IngredientName
                });
            }
            return result;
        }

        public IngredientViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Ingredients.Count; ++i)
            {
                if (source.Ingredients[i].IngredientId == id)
                {
                    return new IngredientViewModel
                    {
                        IngredientId = source.Ingredients[i].IngredientId,
                        IngredientName = source.Ingredients[i].IngredientName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(IngredientBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Ingredients.Count; ++i)
            {
                if (source.Ingredients[i].IngredientId > maxId)
                {
                    maxId = source.Ingredients[i].IngredientId;
                }
                if (source.Ingredients[i].IngredientName == model.IngredientName)
                {
                    throw new Exception("Уже есть ингредиент с таким названием");
                }
            }
            source.Ingredients.Add(new Ingredient
            {
                IngredientId = maxId + 1,
                IngredientName = model.IngredientName
            });
        }

        public void UpdElement(IngredientBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Ingredients.Count; ++i)
            {
                if (source.Ingredients[i].IngredientId == model.IngredientId)
                {
                    index = i;
                }
                if (source.Ingredients[i].IngredientName == model.IngredientName &&
                source.Ingredients[i].IngredientId != model.IngredientId)
                {
                    throw new Exception("Уже есть мнгредиент с такими названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Ingredients[index].IngredientName = model.IngredientName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Ingredients.Count; ++i)
            {
                if (source.Ingredients[i].IngredientId == id)
                {
                    source.Ingredients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
