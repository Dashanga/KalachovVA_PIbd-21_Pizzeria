using ForgeModel;
using System.Collections.Generic;

namespace ForgeServiceImplementList
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Customer> Clients { get; set; }

        public List<Ingredient> Components { get; set; }

        public List<PizzaOrder> Orders { get; set; }

        public List<Pizza> Products { get; set; }

        public List<PizzaIngredient> ProductComponents { get; set; }

        private DataListSingleton()
        {
            Clients = new List<Customer>();
            Components = new List<Ingredient>();
            Orders = new List<PizzaOrder>();
            Products = new List<Pizza>();
            ProductComponents = new List<PizzaIngredient>();
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
