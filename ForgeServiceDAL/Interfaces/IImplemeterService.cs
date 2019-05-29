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
    [CustomInterface("Интерфейс для работы с исполнителями")]
    public interface IImplementerService
    {
        [CustomMethod("Метод для получения списка исполнителей")]
        List<ImplementerViewModel> GetList();

        [CustomMethod("Метод для получения исполнителя по идентификатора")]
        ImplementerViewModel GetElement(int id);

        [CustomMethod("Метод для добавления исполнителя")]
        void AddElement(ImplementerBindingModel model);

        [CustomMethod("Метод для изменения исполнителя")]
        void UpdElement(ImplementerBindingModel model);

        [CustomMethod("Метод для удаления исполнителя")]
        void DelElement(int id);

        [CustomMethod("Метод для получения свободного исполнителя")]
        ImplementerViewModel GetFreeWorker();

    }
}
