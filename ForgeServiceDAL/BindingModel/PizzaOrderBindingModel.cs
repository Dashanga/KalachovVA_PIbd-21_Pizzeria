namespace ForgeServiceDAL.BindingModel
{
    public class PizzaOrderBindingModel
    {
        public int PizzaOrderId { get; set; }

        public int CustomerId { get; set; }

        public int PizzaId { get; set; }

        public int PizzaCount { get; set; }

        public decimal TotalCost { get; set; }
    }
}
