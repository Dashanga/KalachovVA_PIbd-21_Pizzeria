using System.Collections.Generic;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;


namespace ForgeServiceDAL.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerViewModel> GetList();

        CustomerViewModel GetElement(int id);

        void AddElement(CutstomerBindingModel model);

        void UpdElement(CutstomerBindingModel model);

        void DelElement(int id);
    }
}
