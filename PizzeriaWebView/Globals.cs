using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;
using ForgeServiceImplementList.Implementations;
using PizzeriaServiceImplementDB;
using PizzeriaServiceImplementDB.Implementations;

namespace PizzeriaWebView
{
    public static class Globals
    {
        public static AbstractDbContext DbContext { get; } = new AbstractDbContext();
        public static ICustomerService CustomerService { get; } = new CustomerServiceDb(DbContext);
        public static IIngredientService IngredientService { get; } = new IngredientServiceDb(DbContext);
        public static IPizzaService PizzaService { get; } = new PizzaServiceDb(DbContext);
        public static IPizzaOrderService PizzaOrderService { get; } = new PizzaOrderServiceDb(DbContext);
        public static IStorageService StorageService { get; } = new StorageServiceDb(DbContext);
    }
}