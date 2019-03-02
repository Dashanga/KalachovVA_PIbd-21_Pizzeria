using System;
using System.Collections.Generic;
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
        public List<PizzaOrderViewModel> GetList()
        {
            List<PizzaOrderViewModel> result = new List<PizzaOrderViewModel>();
            for (int i = 0; i < source.PizzaOrders.Count; ++i)
            {
                string clientFIO = string.Empty;
                for (int j = 0; j < source.Customers.Count; ++j)
                {
                    if (source.Customers[j].CustomerId == source.PizzaOrders[i].CustomerId)
                    {
                        clientFIO = source.Customers[j].FullName;
                        break;
                    }
                }
                string productName = string.Empty;
                for (int j = 0; j < source.Pizzas.Count; ++j)
                {
                    if (source.Pizzas[j].PizzaId == source.PizzaOrders[i].PizzaId)
                    {
                        productName = source.Pizzas[j].PizzaName;
                        break;
                    }
                }
                result.Add(new PizzaOrderViewModel
                {
                    PizzaOrderId = source.PizzaOrders[i].PizzaOrderId,
                    CustomerId = source.PizzaOrders[i].CustomerId,
                    FullName = clientFIO,
                    PizzaId = source.PizzaOrders[i].PizzaId,
                    PizzaName = productName,
                    PizzaCount = source.PizzaOrders[i].PizzaCount,
                    TotalCost = source.PizzaOrders[i].TotalCost,
                    CreationDate = source.PizzaOrders[i].CreationDate.ToLongDateString(),
                    ImplementationDate = source.PizzaOrders[i].ImplementationDate?.ToLongDateString(),
                    State = source.PizzaOrders[i].State.ToString()
                });
            }
            return result;
        }
        public void CreateOrder(PizzaOrderBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.PizzaOrders.Count; ++i)
            {
                if (source.PizzaOrders[i].PizzaOrderId > maxId)
                {
                    maxId = source.Customers[i].CustomerId;
                }
            }
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
            int index = -1;
            for (int i = 0; i < source.PizzaOrders.Count; ++i)
            {
                if (source.PizzaOrders[i].PizzaOrderId == model.PizzaOrderId)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.PizzaOrders[index].State != PizzaOrderStatus.Received)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            source.PizzaOrders[index].ImplementationDate = DateTime.Now;
            source.PizzaOrders[index].State = PizzaOrderStatus.Processing;
        }
        public void FinishOrder(PizzaOrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.PizzaOrders.Count; ++i)
            {
                if (source.Customers[i].CustomerId == model.PizzaOrderId)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.PizzaOrders[index].State != PizzaOrderStatus.Processing)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            source.PizzaOrders[index].State = PizzaOrderStatus.Ready;
        }
        public void PayOrder(PizzaOrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.PizzaOrders.Count; ++i)
            {
                if (source.Customers[i].CustomerId == model.PizzaOrderId)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.PizzaOrders[index].State != PizzaOrderStatus.Ready)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            source.PizzaOrders[index].State = PizzaOrderStatus.Paid;
        }
    }
}
