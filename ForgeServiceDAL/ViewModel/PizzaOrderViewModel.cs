using System.Runtime.Serialization;

namespace ForgeServiceDAL.ViewModel
{
    [DataContract]
    public class PizzaOrderViewModel
    {
        [DataMember]
        public int PizzaOrderId { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public int PizzaId { get; set; }

        [DataMember]
        public int? ImplementerId { get; set; }

        [DataMember]
        public string ImplementerName;

        [DataMember]
        public string PizzaName { get; set; }

        [DataMember]
        public int PizzaCount { get; set; }

        [DataMember]
        public decimal TotalCost { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string CreationDate { get; set; }

        [DataMember]
        public string ImplementationDate { get; set; }
    }
}
