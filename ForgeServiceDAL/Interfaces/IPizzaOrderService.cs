﻿using System.Collections.Generic;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;

namespace ForgeServiceDAL.Interfaces
{
    public interface IPizzaOrderService
    {
        List<PizzaOrderViewModel> GetList();

        List<PizzaOrderViewModel> GetFreeOrders();

        void CreateOrder(PizzaOrderBindingModel model);

        void TakeOrderInWork(PizzaOrderBindingModel model);

        void FinishOrder(PizzaOrderBindingModel model);

        void PayOrder(PizzaOrderBindingModel model);

        void PutIngredientOnStorage(StorageIngredientBindingModel model);
    }
}
