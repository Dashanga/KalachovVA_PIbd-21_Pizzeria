namespace ForgeServiceDAL.BindingModel
{
    public class PizzaIngredientBindingModel
    {
        public int PizzaIngredientId { get; set; }

        public int PizzaId { get; set; }

        public int IngredientId { get; set; }

        public int PizzaIngredientCount { get; set; }
    }
}
