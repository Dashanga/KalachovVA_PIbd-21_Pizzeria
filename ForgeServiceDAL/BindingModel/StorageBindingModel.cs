using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ForgeServiceDAL.BindingModel
{
    [DataContract]
    public class StorageBindingModel
    {
        [DataMember]
        public int StorageId { get; set; }

        [DataMember]
        public string StorageName { get; set; }
    }
}
