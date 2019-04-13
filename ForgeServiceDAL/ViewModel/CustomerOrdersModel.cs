using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ForgeServiceDAL.ViewModel
{
    [DataContract]
    public class CustomerOrdersModel
    {
        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string CreationDate { get; set; }

        [DataMember]
        public string PizzaName { get; set; }

        [DataMember]
        public int PizzaCount { get; set; }

        [DataMember]
        public decimal TotalCost { get; set; }

        [DataMember]
        public string State { get; set; }
    }
}
