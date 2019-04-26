using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;

namespace PizzeriaWebView.Controllers
{
    public class AddStorageIngredientController : Controller
    {
        private IIngredientService ingredientService = Globals.IngredientService;
        private IStorageService storageService = Globals.StorageService;
        private IPizzaOrderService mainService = Globals.PizzaOrderService;

        public ActionResult Index()
        {
            var ingredients = new SelectList(ingredientService.GetList(), "IngredientId", "IngredientName");
            ViewBag.Ingredients = ingredients;

            var storages = new SelectList(storageService.GetList(), "StorageId", "StorageName");
            ViewBag.Storages = storages;
            return View();
        }

        [HttpPost]
        public ActionResult AddIngredientPost()
        {
           mainService.PutIngredientOnStorage(new StorageIngredientBindingModel
            {
                IngredientId = int.Parse(Request["IngredientId"]),
                StorageId = int.Parse(Request["StorageId"]),
                StorageIngredientCount = int.Parse(Request["StorageIngredientCount"])
            });
            return RedirectToAction("Index", "Home");
        }
    }
}