using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ForgeServiceDAL.ViewModel
{
    [DataContract]
    public class StorageViewModel
    {
        [DataMember]
        public int StorageId { get; set; }

        [DataMember]
        public string StorageName { get; set; }

        [DataMember]
        public List<StorageIngredientViewModel> StorageIngredients { get; set; }
    }
}
