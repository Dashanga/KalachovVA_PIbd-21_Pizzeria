using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeModel
{
    public class PizzaIngredient
    {
        public int PizzaIngredientId { get; set; }

        public int PizzaId { get; set; }

        public int IngredientId { get; set; }

        [Required]
        public int PizzaIngredientCount { get; set; }

        public virtual Pizza Pizza { get; set; }

        public virtual Ingredient Ingredient { get; set; }

    }
}
