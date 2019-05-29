using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.WebSockets;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;
using PizzeriaWebApi.Services;

namespace PizzeriaWebApi.Controllers
{
    public class PizzaOrderController : ApiController
    {
        private readonly IPizzaOrderService _service;

        private readonly IImplementerService _serviceImplementer;

        public PizzaOrderController(IPizzaOrderService service, IImplementerService serviceImplementer)
        {
            _service = service;
            _serviceImplementer = serviceImplementer;
        }
        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void CreateOrder(PizzaOrderBindingModel model)
        {
            _service.CreateOrder(model);
        }

        [HttpPost]
        public void PayOrder(PizzaOrderBindingModel model)
        {
            _service.PayOrder(model);
        }

        [HttpPost]
        public void PutComponentOnStock(StorageIngredientBindingModel model)
        {
            _service.PutIngredientOnStorage(model);
        }

        [HttpPost]
        public void StartWork()
        {
            List<PizzaOrderViewModel> orders = _service.GetFreeOrders();
            foreach (var order in orders)
            {
                ImplementerViewModel impl = _serviceImplementer.GetFreeWorker();
                if (impl == null)
                {
                    throw new Exception("Нет сотрудников");
                }

                new WorkImplementer(_service, _serviceImplementer, impl.Id, order.PizzaOrderId);
            }
        }

        public IHttpActionResult GetInfo()
        {
            ReflectionService service = new ReflectionService();
            var list = service.GetInfoByAssembly();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
    }
}
