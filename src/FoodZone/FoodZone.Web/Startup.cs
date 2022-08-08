using FoodZone.Web.Helpers;
using FoodZone.Web.ViewModels;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using Unity;

[assembly: OwinStartup(typeof(FoodZone.Web.Startup))]
namespace FoodZone.Web
{
    public partial class Startup
    {

        public Startup()
        {
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
            app.MapSignalR();
            var container = new UnityContainer();
            GlobalConfiguration.Configuration.UseActivator(new UnityJobActivator(container));

            BackgroundJobFunction job = new BackgroundJobFunction();
            RecurringJob.AddOrUpdate(() => job.AutoCancelReservation(), Cron.Minutely);
            RecurringJob.AddOrUpdate(() => job.AutoExpireVoucher(), Cron.Daily);
            RecurringJob.AddOrUpdate(() => job.ResetAllTable(), Cron.Hourly);

            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                Authorization = new IDashboardAuthorizationFilter[] { new HangfireAuthFilter() }
            });
        }
    }
}
