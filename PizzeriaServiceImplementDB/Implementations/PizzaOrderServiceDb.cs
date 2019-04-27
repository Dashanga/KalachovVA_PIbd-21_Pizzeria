using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgeModel;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;
using System.Configuration;
using System.Data.Entity;
using System.Net;
using System.Net.Mail;


namespace PizzeriaServiceImplementDB.Implementations
{
    public class PizzaOrderServiceDb : IPizzaOrderService
    {
        private AbstractDbContext context;
        public PizzaOrderServiceDb(AbstractDbContext context)
        {
            this.context = context;
        }

        public List<PizzaOrderViewModel> GetFreeOrders()
        {
            List<PizzaOrderViewModel> result = context.PizzaOrders
                .Where(x => x.State == PizzaOrderStatus.Received || x.State ==
                            PizzaOrderStatus.NotEnoughResources)
                .Select(rec => new PizzaOrderViewModel
                {
                    PizzaOrderId = rec.PizzaOrderId
                })
                .ToList();
            return result;
        }

        public List<PizzaOrderViewModel> GetList()
        {
            List<PizzaOrderViewModel> result = context.PizzaOrders.Select(rec => new PizzaOrderViewModel
            {
                PizzaOrderId = rec.PizzaOrderId,
                CustomerId = rec.CustomerId,
                PizzaId = rec.PizzaId,
                CreationDate = SqlFunctions.DateName("dd", rec.CreationDate) + " " +
            SqlFunctions.DateName("mm", rec.CreationDate) + " " +
            SqlFunctions.DateName("yyyy", rec.CreationDate),
                ImplementationDate = rec.ImplementationDate == null ? "" :
            SqlFunctions.DateName("dd",
           rec.ImplementationDate.Value) + " " +
            SqlFunctions.DateName("mm",
           rec.ImplementationDate.Value) + " " +
            SqlFunctions.DateName("yyyy",
           rec.ImplementationDate.Value),
                State = rec.State.ToString(),
                PizzaCount = rec.PizzaCount,
                TotalCost = rec.TotalCost,
                FullName = rec.Customer.FullName,
                PizzaName = rec.Pizza.PizzaName
            })
            .ToList();
            return result;
        }
        public void CreateOrder(PizzaOrderBindingModel model)
        {
            var order = new PizzaOrder
            {
                CustomerId = model.CustomerId,
                PizzaId = model.PizzaId,
                CreationDate = DateTime.Now,
                PizzaCount = model.PizzaCount,
                TotalCost = model.TotalCost,
                State = PizzaOrderStatus.Received
            };
            context.PizzaOrders.Add(order);
            context.SaveChanges();

            var customer = context.Customers.FirstOrDefault(x => x.CustomerId == model.CustomerId);
            SendEmail(customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1}создан успешно",
                order.PizzaOrderId, order.CreationDate.ToShortDateString()));
        }
        public void TakeOrderInWork(PizzaOrderBindingModel model)
        {
        using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    PizzaOrder element = context.PizzaOrders.FirstOrDefault(rec => rec.PizzaOrderId ==
                   model.PizzaOrderId);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.State != PizzaOrderStatus.Received)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var PizzaIngredients = context.PizzaIngredients.Include(rec => rec.Ingredient).Where(rec => rec.PizzaId == element.PizzaId);
                    foreach (var PizzaIngredient in PizzaIngredients)
                    {
                        int countOnStocks = PizzaIngredient.PizzaIngredientCount * element.PizzaCount;
                        var stockIngredients = context.StorageIngredients.Where(rec =>
                       rec.IngredientId == PizzaIngredient.IngredientId);
                        foreach (var stockIngredient in stockIngredients)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (stockIngredient.StorageIngredientCount >= countOnStocks)
                            {
                                stockIngredient.StorageIngredientCount -= countOnStocks;
                                countOnStocks = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStocks -= stockIngredient.StorageIngredientCount;
                                stockIngredient.StorageIngredientCount = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStocks > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                           PizzaIngredient.Ingredient.IngredientName + " требуется " + PizzaIngredient.PizzaIngredientCount + ", нехватает " + countOnStocks);
                         }
                    }
                    element.ImplementationDate = DateTime.Now;
                    element.State = PizzaOrderStatus.Processing;
                    context.SaveChanges();
                    SendEmail(element.Customer.Mail, "Оповещение по заказам",
                        string.Format("Заказ №{0} от {1} передеан в работу", element.PizzaOrderId,
                            element.CreationDate.ToShortDateString()));

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void FinishOrder(PizzaOrderBindingModel model)
        {
            PizzaOrder element = context.PizzaOrders.FirstOrDefault(rec => rec.PizzaOrderId == model.PizzaOrderId);
            if (element == null)
        {
                throw new Exception("Элемент не найден");
            }
            if (element.State != PizzaOrderStatus.Processing)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.State = PizzaOrderStatus.Ready;
            context.SaveChanges();
            SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format("Заказ №{ 0} от { 1}передан на оплату", element.PizzaOrderId, element.CreationDate.ToShortDateString()));
        }

        public void PayOrder(PizzaOrderBindingModel model)
        {
            PizzaOrder element = context.PizzaOrders.FirstOrDefault(rec => rec.PizzaOrderId == model.PizzaOrderId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.State != PizzaOrderStatus.Ready)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.State = PizzaOrderStatus.Paid;
            context.SaveChanges();
            SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format("Заказ №{ 0} от { 1} оплачен успешно", element.PizzaOrderId, element.CreationDate.ToShortDateString()));

        }
        public void PutIngredientOnStorage(StorageIngredientBindingModel model)
        {
            StorageIngredient element = context.StorageIngredients.FirstOrDefault(rec =>
           rec.StorageId == model.StorageId && rec.IngredientId == model.IngredientId);
            if (element != null)
            {
                element.StorageIngredientCount += model.StorageIngredientCount;
            }
            else
            {
                context.StorageIngredients.Add(new StorageIngredient
                {
                    StorageId = model.StorageId,
                    IngredientId = model.IngredientId,
                    StorageIngredientCount = model.StorageIngredientCount
                });
            }
            context.SaveChanges();
        }

        private void SendEmail(string mailAddress, string subject, string text)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = null;
            try
            {
                objMailMessage.From = new
                    MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new
                    NetworkCredential(ConfigurationManager.AppSettings["MailLogin"],
                        ConfigurationManager.AppSettings["MailPassword"]);
                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }
    }
}
