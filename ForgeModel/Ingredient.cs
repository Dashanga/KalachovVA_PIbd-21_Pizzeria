using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeModel
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        [Required]
        public string IngredientName { get; set; }

        [ForeignKey("IngredientId")]
        public virtual List<PizzaIngredient> PizzaIngredients { get; set; }

        [ForeignKey("IngredientId")]
        public virtual List<StorageIngredient> StorageIngredients { get; set; }

    }
}
