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
            for (int i = 0; i < source.Products.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
                List<PizzaIngredientViewModel> productComponents = new List<PizzaIngredientViewModel>();
                for (int j = 0; j < source.ProductComponents.Count; ++j)
                {
                    if (source.ProductComponents[j].PizzaId == source.Products[i].PizzaId)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Components.Count; ++k)
                        {
                            if (source.ProductComponents[j].IngredientId ==
                            source.Components[k].IngredientId)
                            {
                                componentName = source.Components[k].IngredientName;
                                break;
                            }
                        }
                        productComponents.Add(new PizzaIngredientViewModel
                        {
                            PizzaIngredientId = source.ProductComponents[j].PizzaIngredientId,
                            PizzaId = source.ProductComponents[j].PizzaId,
                            IngredientId = source.ProductComponents[j].IngredientId,
                            IngredientName = componentName,
                            PizzaIngredientCount = source.ProductComponents[j].PizzaIngredientCount
                        });
                    }
                }
                result.Add(new PizzaViewModel
                {
                    PizzaId = source.Products[i].PizzaId,
                    PizzaName = source.Products[i].PizzaName,
                    Cost = source.Products[i].Cost,
                    PizzaIngredients = productComponents
                });
            }
            return result;
        }
        public PizzaViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Products.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
            List<PizzaIngredientViewModel> productComponents = new
            List<PizzaIngredientViewModel>();
                for (int j = 0; j < source.ProductComponents.Count; ++j)
                {
                    if (source.ProductComponents[j].PizzaId == source.Products[i].PizzaId)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Components.Count; ++k)
                        {
                            if (source.ProductComponents[j].IngredientId ==
                            source.Components[k].IngredientId)
                            {
                                componentName = source.Components[k].IngredientName;
                                break;
                            }
                        }
                        productComponents.Add(new PizzaIngredientViewModel
                        {
                            PizzaIngredientId = source.ProductComponents[j].PizzaIngredientId,
                            PizzaId = source.ProductComponents[j].PizzaId,
                            IngredientId = source.ProductComponents[j].IngredientId,
                            IngredientName = componentName,
                            PizzaIngredientCount = source.ProductComponents[j].PizzaIngredientCount
                        });
                    }
                }
                if (source.Products[i].PizzaId == id)
                {
                    return new PizzaViewModel
                    {
                        PizzaId = source.Products[i].PizzaId,
                        PizzaName = source.Products[i].PizzaName,
                        Cost = source.Products[i].Cost,
                        PizzaIngredients = productComponents
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

public void AddElement(PizzaBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].PizzaId > maxId)
                {
                    maxId = source.Products[i].PizzaId;
                }
                if (source.Products[i].PizzaName == model.PizzaName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Products.Add(new Pizza
            {
                PizzaId = maxId + 1,
                PizzaName = model.PizzaName,
                Cost = model.Cost
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].PizzaIngredientId > maxPCId)
                {
                    maxPCId = source.ProductComponents[i].PizzaIngredientId;
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
                source.ProductComponents.Add(new PizzaIngredient
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
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].PizzaId == model.PizzaId)
                {
                    index = i;
                }
                if (source.Products[i].PizzaName == model.PizzaName && source.Products[i].PizzaId != model.PizzaId)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Products[index].PizzaName = model.PizzaName;
            source.Products[index].Cost = model.Cost;
            int maxPCId = 0;
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].PizzaIngredientId > maxPCId)
                {
                    maxPCId = source.ProductComponents[i].PizzaIngredientId;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].PizzaId == model.PizzaId)
                {
                    bool flag = true;
                    for (int j = 0; j < model.PizzaIngredients.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.ProductComponents[i].PizzaIngredientId ==
                        model.PizzaIngredients[j].PizzaIngredientId)
                        {
                            source.ProductComponents[i].PizzaIngredientCount =
                            model.PizzaIngredients[j].PizzaIngredientCount;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.ProductComponents.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.PizzaIngredients.Count; ++i)
            {
                if (model.PizzaIngredients[i].PizzaIngredientId == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.ProductComponents.Count; ++j)
                    {
                        if (source.ProductComponents[j].PizzaId == model.PizzaId &&
                        source.ProductComponents[j].IngredientId ==
                        model.PizzaIngredients[i].IngredientId)
                        {
                            source.ProductComponents[j].PizzaIngredientCount +=
                            model.PizzaIngredients[i].PizzaIngredientCount;
                            model.PizzaIngredients[i].PizzaIngredientId =
                            source.ProductComponents[j].PizzaIngredientId;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.PizzaIngredients[i].PizzaIngredientId == 0)
                    {
                        source.ProductComponents.Add(new PizzaIngredient
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
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].PizzaId == id)
                {
                    source.ProductComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].PizzaId == id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
