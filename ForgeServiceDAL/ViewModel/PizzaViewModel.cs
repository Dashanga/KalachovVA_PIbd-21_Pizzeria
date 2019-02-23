using System.Collections.Generic;

namespace ForgeServiceDAL.ViewModel
{
    public class PizzaViewModel
    {
        public int PizzaId { get; set; }

        public string PizzaName { get; set; }

        public decimal Cost { get; set; }

        public List<PizzaIngredientViewModel> PizzaIngredients { get; set; }
    }
}
