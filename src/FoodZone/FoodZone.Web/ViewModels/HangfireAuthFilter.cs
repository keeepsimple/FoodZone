using Hangfire.Annotations;
using Hangfire.Dashboard;
using Microsoft.Owin;
using System;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.ViewModels
{
    public class HangfireAuthFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            var owinContext = new OwinContext(context.GetOwinEnvironment());
            return owinContext.Authentication.User.Identity.IsAuthenticated && owinContext.Authentication.User.IsInRole("Manager");
        }
    }
}