using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForgeModel
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        public string FullName { get; set; }

        [ForeignKey("CustomerId")]
        public virtual List<PizzaOrder> PizzaOrders { get; set; }
    }
}
