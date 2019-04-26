using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeServiceDAL.BindingModel
{
    public class StorageIngredientBindingModel
    {
        public int StorageIngredientId { get; set; }
        public int StorageId { get; set; }
        public int IngredientId { get; set; }
        public int StorageIngredientCount { get; set; }
    }
}
