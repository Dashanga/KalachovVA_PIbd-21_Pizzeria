using System.Runtime.Serialization;

namespace ForgeServiceDAL.BindingModel
{
    [DataContract]
    public class PizzaIngredientBindingModel
    {
        [DataMember]
        public int PizzaIngredientId { get; set; }

        [DataMember]
        public int PizzaId { get; set; }

        [DataMember]
        public int IngredientId { get; set; }

        [DataMember]
        public int PizzaIngredientCount { get; set; }
    }
}
