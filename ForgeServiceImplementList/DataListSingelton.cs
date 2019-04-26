using ForgeModel;
using System.Collections.Generic;
using System.Data.SqlTypes;

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

        public List<Storage> Storages { get; set; }

        public List<StorageIngredient> StorageIngredients { get; set; }


        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Ingredients = new List<Ingredient>();
            PizzaOrders = new List<PizzaOrder>();
            Pizzas = new List<Pizza>();
            PizzaIngredients = new List<PizzaIngredient>();
            Storages = new List<Storage>();
            StorageIngredients = new List<StorageIngredient>();
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
