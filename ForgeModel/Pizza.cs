using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeModel
{
    public class Pizza
    {
        public int PizzaId { get; set; }

        [Required]
        public string PizzaName { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [ForeignKey("PizzaId")]
        public virtual List<PizzaIngredient> PizzaIngredients { get; set; }

        [ForeignKey("PizzaId")]
        public virtual List<PizzaOrder> PizzaOrders { get; set; }
    }
}
