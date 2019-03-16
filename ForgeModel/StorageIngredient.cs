using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeModel
{
    public class StorageIngredient
    {
        public int StorageIngredientId { get; set; }
        public int StorageId { get; set; }
        public int IngredientId { get; set; }

        [Required]
        public int StorageIngredientCount { get; set; }

        public virtual Storage Storage { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
