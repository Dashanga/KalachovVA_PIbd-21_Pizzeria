using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;

namespace PizzeriaWebView.Controllers
{
    public class StoragesController : Controller
    {
        private IStorageService service = Globals.StorageService;

        public ActionResult List()
        {
            return View(service.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            service.AddElement(new StorageBindingModel
            {
                StorageName = Request["StorageName"]
            });
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = service.GetElement(id);
            var bindingModel = new StorageBindingModel
            {
                StorageId = id,
                StorageName = viewModel.StorageName
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost()
        {
            service.UpdElement(new StorageBindingModel
            { 
                StorageId = int.Parse(Request["StorageId"]),
                StorageName = Request["StorageName"]
            });
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            service.DelElement(id);
            return RedirectToAction("List");
        }
    }
}