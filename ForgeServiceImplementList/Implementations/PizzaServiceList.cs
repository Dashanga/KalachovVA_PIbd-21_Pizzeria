using System;
using System.Collections.Generic;
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
            List<PizzaViewModel> result = new List<PizzaViewModel>();
            for (int i = 0; i < source.Pizzas.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<PizzaIngredientViewModel> productComponents = new List<PizzaIngredientViewModel>();
                for (int j = 0; j < source.PizzaIngredients.Count; ++j)
                {
                    if (source.PizzaIngredients[j].PizzaId == source.Pizzas[i].PizzaId)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Ingredients.Count; ++k)
                        {
                            if (source.PizzaIngredients[j].IngredientId ==
                            source.Ingredients[k].IngredientId)
                            {
                                componentName = source.Ingredients[k].IngredientName;
                                break;
                            }
                        }
                        productComponents.Add(new PizzaIngredientViewModel
                        {
                            PizzaIngredientId = source.PizzaIngredients[j].PizzaIngredientId,
                            PizzaId = source.PizzaIngredients[j].PizzaId,
                            IngredientId = source.PizzaIngredients[j].IngredientId,
                            IngredientName = componentName,
                            PizzaIngredientCount = source.PizzaIngredients[j].PizzaIngredientCount
                        });
                    }
                }
                result.Add(new PizzaViewModel
                {
                    PizzaId = source.Pizzas[i].PizzaId,
                    PizzaName = source.Pizzas[i].PizzaName,
                    Cost = source.Pizzas[i].Cost,
                    PizzaIngredients = productComponents
                });
            }
            return result;
        }
        public PizzaViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Pizzas.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
            List<PizzaIngredientViewModel> productComponents = new
            List<PizzaIngredientViewModel>();
                for (int j = 0; j < source.PizzaIngredients.Count; ++j)
                {
                    if (source.PizzaIngredients[j].PizzaId == source.Pizzas[i].PizzaId)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Ingredients.Count; ++k)
                        {
                            if (source.PizzaIngredients[j].IngredientId ==
                            source.Ingredients[k].IngredientId)
                            {
                                componentName = source.Ingredients[k].IngredientName;
                                break;
                            }
                        }
                        productComponents.Add(new PizzaIngredientViewModel
                        {
                            PizzaIngredientId = source.PizzaIngredients[j].PizzaIngredientId,
                            PizzaId = source.PizzaIngredients[j].PizzaId,
                            IngredientId = source.PizzaIngredients[j].IngredientId,
                            IngredientName = componentName,
                            PizzaIngredientCount = source.PizzaIngredients[j].PizzaIngredientCount
                        });
                    }
                }
                if (source.Pizzas[i].PizzaId == id)
                {
                    return new PizzaViewModel
                    {
                        PizzaId = source.Pizzas[i].PizzaId,
                        PizzaName = source.Pizzas[i].PizzaName,
                        Cost = source.Pizzas[i].Cost,
                        PizzaIngredients = productComponents
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

public void AddElement(PizzaBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Pizzas.Count; ++i)
            {
                if (source.Pizzas[i].PizzaId > maxId)
                {
                    maxId = source.Pizzas[i].PizzaId;
                }
                if (source.Pizzas[i].PizzaName == model.PizzaName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Pizzas.Add(new Pizza
            {
                PizzaId = maxId + 1,
                PizzaName = model.PizzaName,
                Cost = model.Cost
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.PizzaIngredients.Count; ++i)
            {
                if (source.PizzaIngredients[i].PizzaIngredientId > maxPCId)
                {
                    maxPCId = source.PizzaIngredients[i].PizzaIngredientId;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.PizzaIngredients.Count; ++i)
            {
                for (int j = 1; j < model.PizzaIngredients.Count; ++j)
                {
                    if (model.PizzaIngredients[i].IngredientId ==
                    model.PizzaIngredients[j].IngredientId)
                    {
                        model.PizzaIngredients[i].PizzaIngredientCount +=
                        model.PizzaIngredients[j].PizzaIngredientCount;
                        model.PizzaIngredients.RemoveAt(j--);
                    }
                }
            }
            // добавляем компоненты
            for (int i = 0; i < model.PizzaIngredients.Count; ++i)
            {
                source.PizzaIngredients.Add(new PizzaIngredient
                {
                    PizzaIngredientId = ++maxPCId,
                    PizzaId = maxId + 1,
                    IngredientId = model.PizzaIngredients[i].IngredientId,
                    PizzaIngredientCount = model.PizzaIngredients[i].PizzaIngredientCount
                });
            }
        }
        public void UpdElement(PizzaBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Pizzas.Count; ++i)
            {
                if (source.Pizzas[i].PizzaId == model.PizzaId)
                {
                    index = i;
                }
                if (source.Pizzas[i].PizzaName == model.PizzaName && source.Pizzas[i].PizzaId != model.PizzaId)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Pizzas[index].PizzaName = model.PizzaName;
            source.Pizzas[index].Cost = model.Cost;
            int maxPCId = 0;
            for (int i = 0; i < source.PizzaIngredients.Count; ++i)
            {
                if (source.PizzaIngredients[i].PizzaIngredientId > maxPCId)
                {
                    maxPCId = source.PizzaIngredients[i].PizzaIngredientId;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.PizzaIngredients.Count; ++i)
            {
                if (source.PizzaIngredients[i].PizzaId == model.PizzaId)
                {
                    bool flag = true;
                    for (int j = 0; j < model.PizzaIngredients.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.PizzaIngredients[i].PizzaIngredientId ==
                        model.PizzaIngredients[j].PizzaIngredientId)
                        {
                            source.PizzaIngredients[i].PizzaIngredientCount =
                            model.PizzaIngredients[j].PizzaIngredientCount;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.PizzaIngredients.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.PizzaIngredients.Count; ++i)
            {
                if (model.PizzaIngredients[i].PizzaIngredientId == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.PizzaIngredients.Count; ++j)
                    {
                        if (source.PizzaIngredients[j].PizzaId == model.PizzaId &&
                        source.PizzaIngredients[j].IngredientId ==
                        model.PizzaIngredients[i].IngredientId)
                        {
                            source.PizzaIngredients[j].PizzaIngredientCount +=
                            model.PizzaIngredients[i].PizzaIngredientCount;
                            model.PizzaIngredients[i].PizzaIngredientId =
                            source.PizzaIngredients[j].PizzaIngredientId;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.PizzaIngredients[i].PizzaIngredientId == 0)
                    {
                        source.PizzaIngredients.Add(new PizzaIngredient
                        {
                            PizzaIngredientId = ++maxPCId,
                            PizzaId = model.PizzaId,
                            IngredientId = model.PizzaIngredients[i].IngredientId,
                            PizzaIngredientCount = model.PizzaIngredients[i].PizzaIngredientCount
                        });
                    }
                }
            }
        }
        public void DelElement(int id)
        {
            // удаяем записи по компонентам при удалении изделия
            for (int i = 0; i < source.PizzaIngredients.Count; ++i)
            {
                if (source.PizzaIngredients[i].PizzaId == id)
                {
                    source.PizzaIngredients.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Pizzas.Count; ++i)
            {
                if (source.Pizzas[i].PizzaId == id)
                {
                    source.Pizzas.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
