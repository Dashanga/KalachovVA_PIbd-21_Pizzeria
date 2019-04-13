using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.Interfaces;

namespace PizzeriaWebApi.Controllers
{
    public class PizzaOrderController : ApiController
    {
        private readonly IPizzaOrderService _service;
        public PizzaOrderController(IPizzaOrderService service)
        {
            _service = service;
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
        public void TakeOrderInWork(PizzaOrderBindingModel model)
        {
            _service.TakeOrderInWork(model);
        }
        [HttpPost]
        public void FinishOrder(PizzaOrderBindingModel model)
        {
            _service.FinishOrder(model);
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
    }
}
