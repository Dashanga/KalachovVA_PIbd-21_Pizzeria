using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgeServiceDAL.Attributes;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;

namespace ForgeServiceDAL.Interfaces
{
    [CustomInterface("Методя для работы с отчетами")]
    public interface IReportService
    {
        [CustomMethod("Метод для сохранения прайс-листа")]
        void SaveProductPrice(ReportBindingModel model);

        [CustomMethod("Метод для получения загрузки склада")]
        List<StorageLoadViewModel> GetStocksLoad();

        [CustomMethod("Метод для сохранения загрузки складов")]
        void SaveStocksLoad(ReportBindingModel model);

        [CustomMethod("Метод для получения заказов")]
        List<CustomerOrdersModel> GetClientOrders(ReportBindingModel model);

        [CustomMethod("Метод для сохранения заказов")]
        void SaveClientOrders(ReportBindingModel model);
    }
}
