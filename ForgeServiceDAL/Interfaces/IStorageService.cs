using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgeServiceDAL.Attributes;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;

namespace ForgeServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы со складами")]
    public interface IStorageService
    {
        [CustomMethod("Метод для получения списка складов")]
        List<StorageViewModel> GetList();

        [CustomMethod("Метод для получения склада по идентификатора")]
        StorageViewModel GetElement(int id);

        [CustomMethod("Метод для добавления склада")]
        void AddElement(StorageBindingModel model);

        [CustomMethod("Метод для изменения склада")]
        void UpdElement(StorageBindingModel model);

        [CustomMethod("Метод для удаления склада")]
        void DelElement(int id);

    }
}
