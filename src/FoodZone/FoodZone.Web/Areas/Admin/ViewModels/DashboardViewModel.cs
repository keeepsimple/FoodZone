using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class DashboardViewModel
    {
        public int ReservationMonthly { get; set; }

        public int ReservationAnnual { get; set; }

        public int NewReservation { get; set; }

        public double CancelPercent { get; set; }

        public double SuccessPercent { get; set; }
    }
}