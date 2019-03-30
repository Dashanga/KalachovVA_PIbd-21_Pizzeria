using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgeServiceDAL.BindingModel;
using ForgeServiceDAL.ViewModel;

namespace ForgeServiceDAL.Interfaces
{
    public interface IReportService
    {
        void SaveProductPrice(ReportBindingModel model);
        List<StorageLoadViewModel> GetStocksLoad();
        void SaveStocksLoad(ReportBindingModel model);
        List<CustomerOrdersModel> GetClientOrders(ReportBindingModel model);
        void SaveClientOrders(ReportBindingModel model);
    }
}
