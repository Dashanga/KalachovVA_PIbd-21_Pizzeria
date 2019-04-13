using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ForgeServiceDAL.ViewModel
{
    [DataMember]
    public class IngredientViewModel
    {
        [DataMember]
        public int IngredientId { get; set; }

        [DataMember]
        public string IngredientName { get; set; }
    }
}
