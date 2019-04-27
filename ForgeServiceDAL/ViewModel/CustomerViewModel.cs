using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ForgeServiceDAL.ViewModel
{
    [DataContract]
    public class CustomerViewModel
    {
        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public List<MessageInfoViewModel> Messages { get; set; }

    }
}
