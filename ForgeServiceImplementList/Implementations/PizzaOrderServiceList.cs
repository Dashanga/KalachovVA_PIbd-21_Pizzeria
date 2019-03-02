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
    }
}
