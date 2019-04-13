using System.Runtime.Serialization;

namespace ForgeServiceDAL.ViewModel
{
    [DataContract]
    public class CustomerViewModel
    {

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string FullName { get; set; }
    }
}
