using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgeModel
{
    public class PizzaOrder
    {
        public int PizzaOrderId { get; set; }

        public int CustomerId { get; set; }

        public int PizzaId { get; set; }

        public int PizzaCount { get; set; }

        public decimal TotalCost { get; set; }

        public PizzaOrderStatus State { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ImplementationDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Pizza Pizza { get; set; }
    }
}
