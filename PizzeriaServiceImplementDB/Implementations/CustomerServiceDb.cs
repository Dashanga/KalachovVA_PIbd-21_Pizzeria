using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgeModel;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;

namespace PizzeriaServiceImplementDB.Implementations
{
    public class CustomerServiceDb : ICustomerService
    {
        private AbstractDbContext context;

        public CustomerServiceDb(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<CustomerViewModel> GetList()
        {
            List<CustomerViewModel> result = context.Customers.Select(rec => new
                    CustomerViewModel
            {
                CustomerId = rec.CustomerId,
                FullName = rec.FullName,
                Mail = rec.Mail
            })
                .ToList();
            return result;
        }
        public CustomerViewModel GetElement(int id)
        {
            Customer element = context.Customers.FirstOrDefault(rec => rec.CustomerId == id);
            if (element != null)
            {
                return new CustomerViewModel
                {
                    CustomerId = element.CustomerId,
                    FullName = element.FullName,
                    Mail = element.Mail,
                    Messages = context.MessageInfos
                        .Where(recM => recM.CustomerId == element.CustomerId)
                        .Select(recM => new MessageInfoViewModel
                        {
                            MessageId = recM.MessageId,
                            DateDelivery = recM.DateDelivery,
                            Subject = recM.Subject,
                            Body = recM.Body
                        })
                        .ToList()

                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(CutstomerBindingModel model)
        {
            Customer element = context.Customers.FirstOrDefault(rec => rec.FullName ==
                                                                   model.FullName);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Customers.Add(new Customer
            {
                FullName = model.FullName,
                Mail = model.Mail
            });
            context.SaveChanges();
        }
        public void UpdElement(CutstomerBindingModel model)
        {
            Customer element = context.Customers.FirstOrDefault(rec => rec.FullName ==
                                                                   model.FullName && rec.CustomerId != model.CustomerId);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Customers.FirstOrDefault(rec => rec.CustomerId == model.CustomerId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.FullName = model.FullName;
            element.Mail = model.Mail;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Customer element = context.Customers.FirstOrDefault(rec => rec.CustomerId == id);
            if (element != null)
            {
                context.Customers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
