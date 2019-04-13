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
    public class ReportController : ApiController
    {
        private readonly IReportService _service;
        public ReportController(IReportService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetStocksLoad()
        {
            var list = _service.GetStocksLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public IHttpActionResult GetClientOrders(ReportBindingModel model)
        {
            var list = _service.GetClientOrders(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void SaveProductPrice(ReportBindingModel model)
        {
            _service.SaveProductPrice(model);
        }
        [HttpPost]
        public void SaveStocksLoad(ReportBindingModel model)
        {
            _service.SaveStocksLoad(model);
        }
        [HttpPost]
        public void SaveClientOrders(ReportBindingModel model)
        {
            _service.SaveClientOrders(model);
        }

    }
}
