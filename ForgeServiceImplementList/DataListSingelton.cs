using ForgeModel;
using System.Collections.Generic;

namespace ForgeServiceImplementList
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Customer> Customers { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<PizzaOrder> PizzaOrders { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public List<PizzaIngredient> PizzaIngredients { get; set; }

        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Ingredients = new List<Ingredient>();
            PizzaOrders = new List<PizzaOrder>();
            Pizzas = new List<Pizza>();
            PizzaIngredients = new List<PizzaIngredient>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
