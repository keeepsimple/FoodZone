using FoodZone.Data.Infrastructure;
using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using FoodZone.Web.Areas.Identity.Controllers;
using FoodZone.Web.Controllers;
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
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ITableServices, TableServices>();
            container.RegisterType<IBlogServices, BlogServices>();
            container.RegisterType<ICategoryServices, CategoryServices>();
            container.RegisterType<IFoodServices, FoodServices>();
            container.RegisterType<IMenuCategoryServices, MenuCategoryServices>();
            container.RegisterType<IMenuServices, MenuServices>();
            container.RegisterType<INotifyServices, NotifyServices>();
            container.RegisterType<IReservationServices, ReservationServices>();
            container.RegisterType<IReservationDetailsServices, ReservationDetailServices>();
            container.RegisterType<IUserBlogServices, UserBlogServices>();
            container.RegisterType<IUserMenuServices, UserMenuServices>();
            container.RegisterType<IUserVoucherServices, UserVoucherServices>();
            container.RegisterType<IVoucherServices, VoucherServices>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<RolesAdminController>(new InjectionConstructor());
            container.RegisterType<UsersAdminController>(new InjectionConstructor());
        }
    }
}