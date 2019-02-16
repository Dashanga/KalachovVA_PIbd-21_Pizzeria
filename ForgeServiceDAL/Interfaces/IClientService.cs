using System.Collections.Generic;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;


namespace ForgeServiceDAL.Interfaces
{
    public interface IClientService
    {
        List<ClientViewModel> GetList();

        ClientViewModel GetElement(int id);

        void AddElement(ClientBindingModel model);

        void UpdElement(ClientBindingModel model);

        void DelElement(int id);
    }
}
