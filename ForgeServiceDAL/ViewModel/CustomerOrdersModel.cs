using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeServiceDAL.ViewModel
{
    public class CustomerOrdersModel
    {
        public string FullName { get; set; }
        public string CreationDate { get; set; }
        public string PizzaName { get; set; }
        public int PizzaCount { get; set; }
        public decimal TotalCost { get; set; }
        public string State { get; set; }
    }
}
