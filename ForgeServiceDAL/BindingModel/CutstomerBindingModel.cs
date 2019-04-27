using System.Runtime.Serialization;

namespace ForgeServiceDAL.BindingModel
{
    [DataContract]
    public class CutstomerBindingModel
    {
        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Mail { get; set; }
    }
}
