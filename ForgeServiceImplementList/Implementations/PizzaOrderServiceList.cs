using System;
using System.Collections.Generic;
using System.Linq;
using ForgeModel;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;
using ForgeServiceDAL.Interfaces;


namespace ForgeServiceImplementList.Implementations
{
    public class PizzaOrderServiceList : IPizzaOrderService
    {
        private DataListSingleton source;
        public PizzaOrderServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<PizzaOrderViewModel> GetFreeOrders()
        {
            return null;
        }

        public List<PizzaOrderViewModel> GetList()
        {
            List<PizzaOrderViewModel> result = source.PizzaOrders
                .Select(rec => new PizzaOrderViewModel
                {
                    PizzaOrderId = rec.PizzaOrderId,
                    CustomerId = rec.CustomerId,
                    PizzaId = rec.PizzaId,
                    CreationDate = rec.CreationDate.ToLongDateString(),
                    ImplementationDate = rec.ImplementationDate?.ToLongDateString(),
                    State = rec.State.ToString(),
                    PizzaCount = rec.PizzaCount,
                    TotalCost = rec.TotalCost,
                    FullName = source.Customers.FirstOrDefault(recC => recC.CustomerId ==
                                                                      rec.CustomerId)?.FullName,
                    PizzaName = source.Pizzas.FirstOrDefault(recP => recP.PizzaId ==
                                                                         rec.PizzaId)?.PizzaName,
                })
                .ToList();
            return result;
        }

        public void CreateOrder(PizzaOrderBindingModel model)
        {
            int maxId = source.PizzaOrders.Count > 0 ? source.PizzaOrders.Max(rec => rec.PizzaOrderId) : 0;
            source.PizzaOrders.Add(new PizzaOrder
            {
                PizzaOrderId = maxId + 1,
                CustomerId = model.CustomerId,
                PizzaId = model.PizzaId,
                CreationDate = DateTime.Now,
                PizzaCount = model.PizzaCount,
                TotalCost = model.TotalCost,
                State = PizzaOrderStatus.Received
            });
        }

        public void TakeOrderInWork(PizzaOrderBindingModel model)
        {
            PizzaOrder element = source.PizzaOrders.FirstOrDefault(rec => rec.PizzaOrderId == model.PizzaOrderId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.State != PizzaOrderStatus.Received)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // смотрим по количеству компонентов на складах
            var productComponents = source.PizzaIngredients.Where(rec => rec.PizzaId
                                                                          == element.PizzaId);
            foreach (var productComponent in productComponents)
            {
                int countOnStocks = source.StorageIngredients
                    .Where(rec => rec.StorageIngredientId ==
                                  productComponent.IngredientId)
                    .Sum(rec => rec.StorageIngredientCount);
                if (countOnStocks < productComponent.PizzaIngredientCount * element.PizzaCount)
                {
                    var componentName = source.Ingredients.FirstOrDefault(rec => rec.IngredientId ==
                                                                                productComponent.IngredientId);
                    throw new Exception("Не достаточно компонента " +
                                        componentName?.IngredientName + " требуется " + (productComponent.PizzaIngredientCount * element.PizzaCount) +
                                        ", в наличии " + countOnStocks);
                }
            }
            // списываем
            foreach (var productComponent in productComponents)
            {
                int countOnStocks = productComponent.PizzaIngredientCount * element.PizzaCount;
                var stockComponents = source.StorageIngredients.Where(rec => rec.StorageIngredientId
                                                                          == productComponent.IngredientId);
                foreach (var stockComponent in stockComponents)
                {
                    // компонентов на одном слкаде может не хватать
                    if (stockComponent.StorageIngredientCount >= countOnStocks)
                    {
                        stockComponent.StorageIngredientCount -= countOnStocks;
                        break;
                    }
                    else
                    {
                        countOnStocks -= stockComponent.StorageIngredientCount;
                        stockComponent.StorageIngredientCount = 0;
                    }
                }
            }
            element.ImplementationDate = DateTime.Now;
            element.State = PizzaOrderStatus.Processing;
        }

        public void FinishOrder(PizzaOrderBindingModel model)
        {
            PizzaOrder element = source.PizzaOrders.FirstOrDefault(rec => rec.PizzaOrderId == model.PizzaOrderId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.State != PizzaOrderStatus.Processing)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.State = PizzaOrderStatus.Ready;
        }

        public void PayOrder(PizzaOrderBindingModel model)
        {
            PizzaOrder element = source.PizzaOrders.FirstOrDefault(rec => rec.PizzaOrderId == model.PizzaOrderId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.State != PizzaOrderStatus.Ready)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.State = PizzaOrderStatus.Paid;
        }

        public void PutIngredientOnStorage(StorageIngredientBindingModel model)
        {
            StorageIngredient element = source.StorageIngredients.FirstOrDefault(rec =>
                rec.StorageId == model.StorageId && rec.IngredientId == model.IngredientId);
            if (element != null)
            {
                element.StorageIngredientCount += model.StorageIngredientCount;
            }
            else
            {
                int maxId = source.StorageIngredients.Count > 0 ?
                    source.StorageIngredients.Max(rec => rec.StorageIngredientId) : 0;
                source.StorageIngredients.Add(new StorageIngredient
                {
                    StorageIngredientId = ++maxId,
                    StorageId = model.StorageId,
                    IngredientId = model.IngredientId,
                    StorageIngredientCount = model.StorageIngredientCount
                });
            }
        }
    }
}
