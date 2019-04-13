using System.Runtime.Serialization;

namespace ForgeServiceDAL.BindingModel
{
    [DataContract]
    public class PizzaOrderBindingModel
    {
        [DataMember]
        public int PizzaOrderId { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public int PizzaId { get; set; }

        [DataMember]
        public int PizzaCount { get; set; }

        [DataMember]
        public decimal TotalCost { get; set; }
    }
}
