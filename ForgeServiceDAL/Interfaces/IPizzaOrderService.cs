using System.Collections.Generic;
using ForgeServiceDAL.Attributes;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;

namespace ForgeServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с заказами")]
    public interface IPizzaOrderService
    {
        [CustomMethod("Метод для получения списка пицц")]
        List<PizzaOrderViewModel> GetList();

        [CustomMethod("Метод для получения списка свободными заказами")]
        List<PizzaOrderViewModel> GetFreeOrders();

        [CustomMethod("Метод для создания заказ")]
        void CreateOrder(PizzaOrderBindingModel model);

        [CustomMethod("Метод для принятия заказа")]
        void TakeOrderInWork(PizzaOrderBindingModel model);

        [CustomMethod("Метод для выполнения заказа")]
        void FinishOrder(PizzaOrderBindingModel model);

        [CustomMethod("Метод для оплаты заказа")]
        void PayOrder(PizzaOrderBindingModel model);

        [CustomMethod("Метод для добавления ингредиентов на склад")]
        void PutIngredientOnStorage(StorageIngredientBindingModel model);
    }
}
