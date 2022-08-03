using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using FoodZone.Web.Helpers;
using FoodZone.Web.ViewModels;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;

[assembly: OwinStartup(typeof(FoodZone.Web.Startup))]
namespace FoodZone.Web
{
    public partial class Startup
    {
        private readonly IReservationServices _reservationServices;
        private readonly IReservationDetailsServices _reservationDetailServices;
        private readonly ITableServices _tableServices;

        public Startup()
        {
            _reservationServices = DependencyResolver.Current.GetService<IReservationServices>();
            _reservationDetailServices = DependencyResolver.Current.GetService<IReservationDetailsServices>();
            _tableServices = DependencyResolver.Current.GetService<ITableServices>();
        }

        private IEnumerable<IDisposable> GetHangfireServers()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Server=.;Database=FoodZone;Trusted_Connection=True;", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromSeconds(15),
                    SlidingInvisibilityTimeout = TimeSpan.FromSeconds(15),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                });
            yield return new BackgroundJobServer();
        }

        public void Configuration(IAppBuilder app)
        {
            app.UseHangfireAspNet(GetHangfireServers);
            ConfigureAuth(app);
            var container = new UnityContainer();
            GlobalConfiguration.Configuration.UseActivator(new UnityJobActivator(container));

            BackgroundJobFunction job = new BackgroundJobFunction();
            RecurringJob.AddOrUpdate(() => job.AutoCancelReservation(), Cron.Minutely);
            RecurringJob.AddOrUpdate(() => job.AutoExpireVoucher(), Cron.Daily);

            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                Authorization = new IDashboardAuthorizationFilter[] { new HangfireAuthFilter() }
            });
        }
    }
}
