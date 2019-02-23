using System.Collections.Generic;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;



namespace ForgeServiceDAL.Interfaces
{
    public interface IPizzaService
    {
        List<PizzaViewModel> GetList();

        PizzaViewModel GetElement(int id);

        void AddElement(PizzaBindingModel model);

        void UpdElement(PizzaBindingModel model);

        void DelElement(int id);
    }
}
