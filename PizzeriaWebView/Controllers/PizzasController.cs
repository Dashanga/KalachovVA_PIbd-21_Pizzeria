using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForgeServiceDAL.Interfaces;

namespace PizzeriaWebView.Controllers
{
    public class PizzasController : Controller
    {
        public IPizzaService service = Globals.PizzaService;
        // GET: Pizzas
        public ActionResult Index()
        {
            return View(service.GetList());
        }

        public ActionResult Delete(int id)
        {
            service.DelElement(id);
            return RedirectToAction("Index");
        }
    }
}