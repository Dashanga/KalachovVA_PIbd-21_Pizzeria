using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;

namespace PizzeriaWebView.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService service = Globals.PizzaService;
        private IIngredientService ingredientService = Globals.IngredientService;

        // GET: Pizzas
        public ActionResult Index()
        {
            if (Session["Pizza"] == null)
            {
                var pizza = new PizzaViewModel();
                pizza.PizzaIngredients = new List<PizzaIngredientViewModel>();
                Session["Pizza"] = pizza;
            }
            return View((PizzaViewModel) Session["Pizza"]);
        }

        public ActionResult AddIngredient()
        {
            var ingredients = new SelectList(ingredientService.GetList(), "IngredientId", "IngredientName");
            ViewBag.Ingredients = ingredients;
            return View();
        }

        [HttpPost]
        public ActionResult AddIngredientPost()
        {
            var pizza = (PizzaViewModel) Session["Pizza"];
            var ingredient = new PizzaIngredientViewModel
            {
                IngredientId = int.Parse(Request["IngredientId"]),
                IngredientName = ingredientService.GetElement(int.Parse(Request["IngredientId"])).IngredientName,
                PizzaIngredientCount = int.Parse(Request["PizzaIngredientCount"])
            };
            pizza.PizzaIngredients.Add(ingredient);
            Session["Pizza"] = pizza;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreatePizzaPost()
        {
            var pizza = (PizzaViewModel) Session["Pizza"];
            var pizzaIngredeints = new List<PizzaIngredientBindingModel>();
            for (int i = 0; i < pizza.PizzaIngredients.Count; ++i)
            {
                pizzaIngredeints.Add(new PizzaIngredientBindingModel
                {
                    PizzaIngredientId = pizza.PizzaIngredients[i].PizzaIngredientId,
                    PizzaId = pizza.PizzaIngredients[i].PizzaId,
                    IngredientId = pizza.PizzaIngredients[i].IngredientId,
                    PizzaIngredientCount = pizza.PizzaIngredients[i].PizzaIngredientCount
                });
            }
            service.AddElement(new PizzaBindingModel
            {
                PizzaName = Request["PizzaName"],
                Cost = Convert.ToDecimal(Request["Cost"]),
                PizzaIngredients = pizzaIngredeints
            });
            Session.Remove("Pizza");
            return RedirectToAction("Index", "Pizzas");
        }
    }
}