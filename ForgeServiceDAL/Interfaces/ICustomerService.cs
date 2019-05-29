using System.Collections.Generic;
using ForgeServiceDAL.Attributes;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;


namespace ForgeServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с клиентами")]
    public interface ICustomerService
    {
        [CustomMethod("Метод для получения списка клиентов")]
        List<CustomerViewModel> GetList();

        [CustomMethod("Метод для получения клиента по идентификатору")]
        CustomerViewModel GetElement(int id);

        [CustomMethod("Метод добавления клиента")]
        void AddElement(CutstomerBindingModel model);

        [CustomMethod("Метод изменения клиента")]
        void UpdElement(CutstomerBindingModel model);

        [CustomMethod("Метод удаления клиента")]
        void DelElement(int id);
    }
}
