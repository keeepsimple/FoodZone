using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FoodZone.Web.ViewModels
{
    public class ReservationDetailViewModel
    {
        public int Id { get; set; }

        public string CusName { get; set; }

        public string PhoneNumber { get; set; }

        public int Status { get; set; }

        public DateTime ReservationDate { get; set; }

        public string Code { get; set; }

        public string Note { get; set; }

        public string CancelReason { get; set; }
    }
}