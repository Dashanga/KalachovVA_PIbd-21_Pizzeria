using System.Runtime.Serialization;

namespace ForgeServiceDAL.ViewModel
{
    [DataContract]
    public class PizzaIngredientViewModel
    {
        [DataMember]
        public int PizzaIngredientId { get; set; }

        [DataMember]
        public int PizzaId { get; set; }

        [DataMember]
        public int IngredientId { get; set; }

        [DataMember]
        public string IngredientName { get; set; }

        [DataMember]
        public int PizzaIngredientCount { get; set; }
    }
}
