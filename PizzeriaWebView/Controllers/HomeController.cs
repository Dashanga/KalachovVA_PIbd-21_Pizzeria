using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForgeServiceDAL.Interfaces;
using ForgeServiceImplementList.Implementations;

namespace PizzeriaWebView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customers()
        {
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Ingredients()
        {
            return RedirectToAction("Index", "Ingredients");
        }

        public ActionResult Pizzas()
        {
            return RedirectToAction("Index", "Pizzas");
        }

        public ActionResult PizzaOrders()
        {
            return RedirectToAction("Index", "PizzaOrder");
        }
    }
}