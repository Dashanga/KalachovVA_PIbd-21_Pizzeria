namespace ForgeServiceDAL.ViewModel
{
    public class PizzaOrderViewModel
    {
        public int PizzaOrderId { get; set; }

        public int CustomerId { get; set; }

        public string FullName { get; set; }

        public int PizzaId { get; set; }

        public string PizzaName { get; set; }

        public int PizzaCount { get; set; }

        public decimal TotalCost { get; set; }

        public string State { get; set; }

        public string CreationDate { get; set; }

        public string ImplementationDate { get; set; }
    }
}
