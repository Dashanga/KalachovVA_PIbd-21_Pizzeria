using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ForgeServiceDAL.Interfaces;
using ForgeServiceDAL.ViewModel;
using ForgeServiceImplementList.Implementations;

namespace PizzeriaWebView
{
    public static class Globals
    {
        public static ICustomerService CustomerService { get; } = new CustomerServiceList();
        public static IIngredientService IngredientService { get; } = new IngredientServiceList();
        public static IPizzaService PizzaService { get; } = new PizzaServiceList();
    }
}