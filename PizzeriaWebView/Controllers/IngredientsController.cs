using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;

namespace PizzeriaWebView.Controllers
{
    public class IngredientsController : Controller
    {
        private IIngredientService service = Globals.IngredientService;
        // GET: Ingredients
        public ActionResult Index()
        {
            return View(service.GetList());
        }


        // GET: Ingredients/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreatePost()
        {
            service.AddElement( new IngredientBindingModel
            {
                IngredientName = Request["IngredientName"]
            });
            return RedirectToAction("Index");
        }


        // GET: Ingredients/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = service.GetElement(id);
            var bindingModel = new IngredientBindingModel
            {
                IngredientId = id,
                IngredientName = viewModel.IngredientName
            };
            return View(bindingModel);
        }


        [HttpPost]
        public ActionResult EditPost()
        {
            service.UpdElement(new IngredientBindingModel
            {
                IngredientId = int.Parse(Request["IngredientId"]),
                IngredientName = Request["IngredientName"]
            });
            return RedirectToAction("Index");
        }


        // GET: Ingredients/Delete/5
        public ActionResult Delete(int id)
        {
            service.DelElement(id);
            return RedirectToAction("Index");
        }
    }
}
