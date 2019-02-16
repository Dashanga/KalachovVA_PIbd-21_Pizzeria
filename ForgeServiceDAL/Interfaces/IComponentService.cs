using System.Collections.Generic;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;

namespace ForgeServiceDAL.Interfaces
{
    public interface IComponentService
    {
        List<ComponentViewModel> GetList();

        ComponentViewModel GetElement(int id);

        void AddElement(ComponentBindingModel model);

        void UpdElement(ComponentBindingModel model);

        void DelElement(int id);
    }
}
