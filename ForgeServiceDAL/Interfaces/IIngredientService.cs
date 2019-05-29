using System.Collections.Generic;
using ForgeServiceDAL.Attributes;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;

namespace ForgeServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с ингредиентами")]
    public interface IIngredientService
    {
        [CustomMethod("Метод для получения списка ингредиентов")]
        List<IngredientViewModel> GetList();

        [CustomMethod("Метод для получения ингредиента по идентификатору")]
        IngredientViewModel GetElement(int id);

        [CustomMethod("Метод для добавления ингредиента")]
        void AddElement(IngredientBindingModel model);

        [CustomMethod("Метод для изменения ингредиента")]
        void UpdElement(IngredientBindingModel model);

        [CustomMethod("Метод для удаления ингредиента")]
        void DelElement(int id);
    }
}
