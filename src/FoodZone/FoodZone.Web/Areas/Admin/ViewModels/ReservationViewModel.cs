using FoodZone.Models.Common;
using FoodZone.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string PhoneNumber { get; set; }

        public int Status { get; set; }

        public decimal TotalPrice { get; set; }

        public string Name { get; set; }

        public DateTime ReservationDate { get; set; }

        public int Adult { get; set; }

        public int Child { get; set; }

        public string Note { get; set; }

        public string CancelReason { get; set; }
    }
}