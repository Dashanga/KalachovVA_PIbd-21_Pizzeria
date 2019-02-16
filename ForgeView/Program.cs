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
            currentContainer.RegisterType<IClientService, ClientServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IComponentService, ComponentServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductService, ProductServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceList>(new
           HierarchicalLifetimeManager());
        return currentContainer;
        }
    }
}
