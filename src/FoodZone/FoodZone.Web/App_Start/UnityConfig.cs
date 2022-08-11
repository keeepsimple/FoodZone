using FoodZone.Data;
using FoodZone.Data.Infrastructure;
using FoodZone.Data.Infrastructure.Repositories;
using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using FoodZone.Web.Areas.Identity.Controllers;
using FoodZone.Web.Controllers;
using Hangfire.Client;
using Hangfire.Common;
using Hangfire.States;
using Hangfire;
using System;

using Unity;
using Unity.Injection;

namespace FoodZone.Web
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
        [Obsolete]
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            // TODO: Register your type's mappings here.
            container.RegisterSingleton<FoodZoneContext, FoodZoneContext>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ICoreRepository<Menu>, CoreRepository<Menu>>();
            container.RegisterType<ICoreRepository<Reservation>, CoreRepository<Reservation>>();
            container.RegisterType<ICoreRepository<ReservationDetail>, CoreRepository<ReservationDetail>>();
            container.RegisterType<ICheckoutServices, CheckoutServices>();
            container.RegisterType<ITableServices, TableServices>();
            container.RegisterType<INewsServices, NewsServices>();
            container.RegisterType<ICategoryServices, CategoryServices>();
            container.RegisterType<IFoodServices, FoodServices>();
            container.RegisterType<IMenuCategoryServices, MenuCategoryServices>();
            container.RegisterType<IMenuServices, MenuServices>();
            container.RegisterType<IReservationServices, ReservationServices>();
            container.RegisterType<IReservationDetailsServices, ReservationDetailServices>();
            container.RegisterType<IUserMenuServices, UserMenuServices>();
            container.RegisterType<IUserVoucherServices, UserVoucherServices>();
            container.RegisterType<IVoucherServices, VoucherServices>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<DashboardController>(new InjectionConstructor());
            container.RegisterType<RolesAdminController>(new InjectionConstructor());
            container.RegisterType<UsersAdminController>(new InjectionConstructor());
            container.RegisterType<JobStorage>(new InjectionFactory(c => JobStorage.Current));
            container.RegisterType<IJobFilterProvider, JobFilterAttributeFilterProvider>(new InjectionConstructor(true));
            container.RegisterType<IBackgroundJobFactory, BackgroundJobFactory>();
            container.RegisterType<IRecurringJobManager, RecurringJobManager>();
            container.RegisterType<IBackgroundJobClient, BackgroundJobClient>();
            container.RegisterType<IBackgroundJobStateChanger, BackgroundJobStateChanger>();
        }
    }
    
}