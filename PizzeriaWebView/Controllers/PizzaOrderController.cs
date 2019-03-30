using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;

namespace PizzeriaWebView.Controllers
{
    public class PizzaOrderController : Controller
    {
        private IPizzaService pizzasService = Globals.PizzaService;
        private IPizzaOrderService pizzaOrderService = Globals.PizzaOrderService;
        private ICustomerService customerService = Globals.CustomerService;


        // GET: PizzaOrder
        public ActionResult Index()
        {
            return View(pizzaOrderService.GetList());
        }

        public ActionResult Create()
        {
            var pizzas = new SelectList(pizzasService.GetList(), "PizzaId", "PizzaName");
            var customers = new SelectList(customerService.GetList(), "CustomerId", "FullName");
            ViewBag.Pizzas = pizzas;
            ViewBag.Customers = customers;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            var customerId = int.Parse(Request["CustomerId"]);
            var pizzaId = int.Parse(Request["PizzaId"]);
            var pizzaCount = int.Parse(Request["PizzaCount"]);
            var totalCost = CalcSum(pizzaId, pizzaCount);

            pizzaOrderService.CreateOrder(new PizzaOrderBindingModel
            {
                CustomerId = customerId,
                PizzaId = pizzaId,
                PizzaCount = pizzaCount,
                TotalCost = totalCost

            });
            return RedirectToAction("Index");
        }

        private Decimal CalcSum(int pizzaId, int pizzaCount)
        {
            PizzaViewModel pizza = pizzasService.GetElement(pizzaId);
            return pizzaCount * pizza.Cost;
        }

        public ActionResult SetStatus(int id, string status)
        {
            try
            {
                switch (status)
                {
                    case "Processing":
                        pizzaOrderService.TakeOrderInWork(new PizzaOrderBindingModel {PizzaOrderId = id});
                        break;
                    case "Ready":
                        pizzaOrderService.FinishOrder(new PizzaOrderBindingModel {PizzaOrderId = id});
                        break;
                    case "Paid":
                        pizzaOrderService.PayOrder(new PizzaOrderBindingModel {PizzaOrderId = id});
                        break;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }
            

            return RedirectToAction("Index");
        }
    }
}