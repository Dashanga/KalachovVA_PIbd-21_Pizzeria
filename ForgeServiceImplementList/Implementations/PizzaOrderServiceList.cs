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
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                string clientFIO = string.Empty;
                for (int j = 0; j < source.Clients.Count; ++j)
                {
                    if (source.Clients[j].CustomerId == source.Orders[i].CustomerId)
                    {
                        clientFIO = source.Clients[j].FullName;
                        break;
                    }
                }
                string productName = string.Empty;
                for (int j = 0; j < source.Products.Count; ++j)
                {
                    if (source.Products[j].PizzaId == source.Orders[i].PizzaId)
                    {
                        productName = source.Products[j].PizzaName;
                        break;
                    }
                }
                result.Add(new PizzaOrderViewModel
                {
                    PizzaOrderId = source.Orders[i].PizzaOrderId,
                    CustomerId = source.Orders[i].CustomerId,
                    FullName = clientFIO,
                    PizzaId = source.Orders[i].PizzaId,
                    PizzaName = productName,
                    PizzaCount = source.Orders[i].PizzaCount,
                    TotalCost = source.Orders[i].TotalCost,
                    CreationDate = source.Orders[i].CreationDate.ToLongDateString(),
                    ImplementationDate = source.Orders[i].ImplementationDate?.ToLongDateString(),
                    State = source.Orders[i].State.ToString()
                });
            }
            return result;
        }
        public void CreateOrder(PizzaOrderBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].PizzaOrderId > maxId)
                {
                    maxId = source.Clients[i].CustomerId;
                }
            }
            source.Orders.Add(new PizzaOrder
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
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].PizzaOrderId == model.PizzaOrderId)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].State != PizzaOrderStatus.Received)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            source.Orders[index].ImplementationDate = DateTime.Now;
            source.Orders[index].State = PizzaOrderStatus.Processing;
        }
        public void FinishOrder(PizzaOrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Clients[i].CustomerId == model.PizzaOrderId)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].State != PizzaOrderStatus.Processing)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            source.Orders[index].State = PizzaOrderStatus.Ready;
        }
        public void PayOrder(PizzaOrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Clients[i].CustomerId == model.PizzaOrderId)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].State != PizzaOrderStatus.Ready)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            source.Orders[index].State = PizzaOrderStatus.Paid;
        }
    }
}
