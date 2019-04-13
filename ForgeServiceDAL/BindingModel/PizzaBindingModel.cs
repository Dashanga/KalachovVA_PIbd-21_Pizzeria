using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ForgeServiceDAL.BindingModel
{
    [DataContract]
    public class PizzaBindingModel
    {
        [DataMember]
        public int PizzaId { get; set; }

        [DataMember]
        public string PizzaName { get; set; }

        [DataMember]
        public decimal Cost { get; set; }

        [DataMember]
        public List<PizzaIngredientBindingModel> PizzaIngredients { get; set; }
    }
}
