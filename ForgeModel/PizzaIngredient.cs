using System;
using System.Collections.Generic;
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

        public int PizzaIngredientCount { get; set; }
    }
}
