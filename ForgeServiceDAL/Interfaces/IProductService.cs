using System.Collections.Generic;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;



namespace ForgeServiceDAL.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetList();

        ProductViewModel GetElement(int id);

        void AddElement(ProductBindingModel model);

        void UpdElement(ProductBindingModel model);

        void DelElement(int id);
    }
}
