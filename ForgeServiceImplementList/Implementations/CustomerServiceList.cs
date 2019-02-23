using System;
using System.Collections.Generic;
using ForgeModel;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;
using ForgeServiceDAL.Interfaces;


namespace ForgeServiceImplementList.Implementations
{
    public class CustomerServiceList : ICustomerService
    {
        private DataListSingleton source;

        public CustomerServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<CustomerViewModel> GetList()
        {
            List<CustomerViewModel> result = new List<CustomerViewModel>();
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                result.Add(new CustomerViewModel
                {
                    CustomerId = source.Clients[i].CustomerId,
                    FullName = source.Clients[i].FullName
                });
            }
        return result;
        }

        public CustomerViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].CustomerId == id)
                {
                    return new CustomerViewModel
                    {
                        CustomerId = source.Clients[i].CustomerId,
                        FullName = source.Clients[i].FullName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CutstomerBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].CustomerId > maxId)
                {
                    maxId = source.Clients[i].CustomerId;
                }
                if (source.Clients[i].FullName == model.FullName)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            source.Clients.Add(new Customer {
                CustomerId = maxId + 1,
                FullName = model.FullName
            });
        }

        public void UpdElement(CutstomerBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].CustomerId == model.CustomerId)
                {
                    index = i;
                }
                if (source.Clients[i].FullName == model.FullName &&
                source.Clients[i].CustomerId != model.CustomerId)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Clients[index].FullName = model.FullName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
        {
                if (source.Clients[i].CustomerId == id)
                {
                    source.Clients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
