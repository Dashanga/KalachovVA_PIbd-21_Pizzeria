using System.Runtime.Serialization;

namespace ForgeServiceDAL.BindingModel
{
    [DataContract]
    public class IngredientBindingModel
    {
        [DataMember]
        public int IngredientId { get; set; }

        [DataMember]
        public string IngredientName { get; set; }
    }
}
