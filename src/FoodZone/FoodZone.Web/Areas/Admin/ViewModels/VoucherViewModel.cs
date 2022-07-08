using System;

namespace FoodZone.Web.Areas.Admin.ViewModels
{
    public class VoucherViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Code { get; set; }

        public string Content { get; set; }

        public int Status { get; set; }

        private DateTime _date = DateTime.Now;
        public DateTime ExpiredDate { get { return _date; } set { _date = value; } }

        public int Level { get; set; }
    }
}