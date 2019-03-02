using System;
using System.Windows.Forms;
using Unity;
using ForgeServiceDAL.Interfaces;
using ForgeServiceImplementList.Implementations;
using Unity.Lifetime;

namespace ForgeView
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICustomerService, CustomerServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIngredientService, IngredientServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPizzaService, PizzaServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPizzaOrderService, PizzaOrderServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageService, StorageServiceList>(new
                HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
