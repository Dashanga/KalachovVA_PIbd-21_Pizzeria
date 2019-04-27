using System;
using System.Data.Entity;
using ForgeServiceDAL.Interfaces;
using ForgeServiceImplementList.Implementations;
using PizzeriaServiceImplementDB;
using PizzeriaServiceImplementDB.Implementations;
using Unity;
using System.Data.Entity;
using Unity.Lifetime;

namespace PizzeriaWebApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<DbContext, AbstractDbContext>(new
                HierarchicalLifetimeManager());
            container.RegisterType<ICustomerService, CustomerServiceDb>(new
                HierarchicalLifetimeManager());
            container.RegisterType<IIngredientService, IngredientServiceDb>(new
                HierarchicalLifetimeManager());
            container.RegisterType<IPizzaService, PizzaServiceDb>(new
                HierarchicalLifetimeManager());
            container.RegisterType<IStorageService, StorageServiceDb>(new
                HierarchicalLifetimeManager());
            container.RegisterType<IPizzaOrderService, PizzaOrderServiceDb>(new
                HierarchicalLifetimeManager());
            container.RegisterType<IReportService, ReportServiceDB>(new
                HierarchicalLifetimeManager());
            container.RegisterType<IImplementerService, ImplementerServiceDB>(new
                HierarchicalLifetimeManager());
            container.RegisterType<IMessageInfoService, MessageInfoServiceDB>(new
                HierarchicalLifetimeManager());
        }
    }
}