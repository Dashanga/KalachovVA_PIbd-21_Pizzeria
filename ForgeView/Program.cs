using System;
using System.Windows.Forms;
using Unity;
using ForgeServiceDAL.Interfaces;
using ForgeServiceImplementList.Implementations;
using PizzeriaServiceImplementDB.Implementations;

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
            currentContainer.RegisterType<ICustomerService, CustomerServiceDb>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIngredientService, IngredientServiceDb>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPizzaService, PizzaServiceDb>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPizzaOrderService, PizzaOrderServiceDb>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageService, StorageServiceDb>(new
                HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportService, ReportServiceDB>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
