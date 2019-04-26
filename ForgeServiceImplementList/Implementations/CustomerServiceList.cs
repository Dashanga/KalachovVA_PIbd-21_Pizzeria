using System;
using System.Collections.Generic;
using System.Linq;
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
            List<CustomerViewModel> result = source.Customers.Select(rec => new CustomerViewModel
            {
                CustomerId = rec.CustomerId,
                FullName = rec.FullName
            }).ToList();
            return result;
        }

        public CustomerViewModel GetElement(int CustomerId)
        {
            Customer el = source.Customers.FirstOrDefault(rec => rec.CustomerId == CustomerId);
            if (el != null)
            {
                return new CustomerViewModel()
                {
                    CustomerId = el.CustomerId,
                    FullName = el.FullName
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CutstomerBindingModel model)
        {
            Customer element = source.Customers.FirstOrDefault(rec => rec.FullName ==
                                                                  model.FullName);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            int maxId = source.Customers.Count > 0 ? source.Customers.Max(rec => rec.CustomerId) : 0;
            source.Customers.Add(new Customer
            {
                CustomerId = maxId + 1,
                FullName = model.FullName
            });
        }

        public void UpdElement(CutstomerBindingModel model)
        {
            Customer element = source.Customers.FirstOrDefault(rec => rec.FullName ==
                                                                  model.FullName && rec.CustomerId != model.CustomerId);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = source.Customers.FirstOrDefault(rec => rec.CustomerId == model.CustomerId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.FullName = model.FullName;
        }

        public void DelElement(int CustomerId)
        {
            Customer element = source.Customers.FirstOrDefault(rec => rec.CustomerId == CustomerId);
            if (element != null)
            {
                source.Customers.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
