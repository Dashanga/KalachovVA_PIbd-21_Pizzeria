using System.Collections.Generic;

namespace ForgeServiceDAL.BindingModel
{
    public class PizzaBindingModel
    {
        public int PizzaId { get; set; }

        public string PizzaName { get; set; }

        public decimal Cost { get; set; }

        public List<PizzaIngredientBindingModel> PizzaIngredients { get; set; }
    }
}
