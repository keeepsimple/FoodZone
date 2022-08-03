using FoodZone.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FoodZone.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //private readonly IReservationServices _reservationServices;
        //private readonly IReservationDetailsServices _reservationDetailServices;
        //private readonly ITableServices _tableServices;

        //public MvcApplication()
        //{
        //    _reservationServices = DependencyResolver.Current.GetService<IReservationServices>();
        //    _reservationDetailServices = DependencyResolver.Current.GetService<IReservationDetailsServices>();
        //    _tableServices = DependencyResolver.Current.GetService<ITableServices>();
        //}

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Timer timer = new Timer();
            //timer.Interval = 60000;
            //timer.Elapsed += timer_Elapsed;
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
