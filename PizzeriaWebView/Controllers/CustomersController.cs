using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceImplementList.Implementations;

namespace PizzeriaWebView.Controllers
{
    public class CustomersController : Controller
    {
        public ICustomerService service = Globals.CustomerService;
        // GET: Customers
        public ActionResult Index()
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
            service.AddElement(new CutstomerBindingModel
            {
                FullName = Request["FullName"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = service.GetElement(id);
            var bindingModel = new CutstomerBindingModel
            {
                CustomerId = id,
                FullName = viewModel.FullName
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost()
        {
            service.UpdElement(new CutstomerBindingModel
            {
                CustomerId = int.Parse(Request["CustomerId"]),
                FullName = Request["FullName"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            service.DelElement(id);
            return RedirectToAction("Index");
        }


    }
}