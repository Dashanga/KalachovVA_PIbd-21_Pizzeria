using System.Collections.Generic;
using ForgeServiceDAL.Attributes;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;



namespace ForgeServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с пиццами")]
    public interface IPizzaService
    {
        [CustomMethod("Метод для получения списка пиццами")]
        List<PizzaViewModel> GetList();

        [CustomMethod("Метод для получения пиццы по идентификатору")]
        PizzaViewModel GetElement(int id);

        [CustomMethod("Метод для получения добавления пиццы")]
        void AddElement(PizzaBindingModel model);

        [CustomMethod("Метод для изменения пиццы")]
        void UpdElement(PizzaBindingModel model);

        [CustomMethod("Метод для удаления пиццы")]
        void DelElement(int id);
    }
}
