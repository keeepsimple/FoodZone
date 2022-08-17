using FoodZone.Services.IServices;
using FoodZone.Web.Areas.Admin.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Manager,Staff")]
    public class DashboardAdminController : Controller
    {
        private readonly IReservationServices _reservationServices;

        public DashboardAdminController(IReservationServices reservationServices)
        {
            _reservationServices = reservationServices;
        }

        public ActionResult Index()
        {
            var annual = _reservationServices.GetAll();
            var monthly = _reservationServices.GetAllReservationMonthly();
            var newReservation = _reservationServices.GetAllReservationToday().Where(x => x.Status == 0);
            var cancelReservation = annual.Where(x => x.Status == -1);
            var successReservation = annual.Where(x => x.Status == 2);

            var jan = annual.Where(x => x.ReservationDate.Month == 1 && x.ReservationDate.Year == DateTime.Now.Year && x.Status == 2).Count();
            var feb = annual.Where(x => x.ReservationDate.Month == 2 && x.ReservationDate.Year == DateTime.Now.Year && x.Status == 2).Count();
            var mar = annual.Where(x => x.ReservationDate.Month == 3 && x.ReservationDate.Year == DateTime.Now.Year && x.Status == 2).Count();
            var apr = annual.Where(x => x.ReservationDate.Month == 4 && x.ReservationDate.Year == DateTime.Now.Year && x.Status == 2).Count();
            var may = annual.Where(x => x.ReservationDate.Month == 5 && x.ReservationDate.Year == DateTime.Now.Year && x.Status == 2).Count();
            var jun = annual.Where(x => x.ReservationDate.Month == 6 && x.ReservationDate.Year == DateTime.Now.Year && x.Status == 2).Count();
            var jul = annual.Where(x => x.ReservationDate.Month == 7 && x.ReservationDate.Year == DateTime.Now.Year && x.Status == 2).Count();
            var aug = annual.Where(x => x.ReservationDate.Month == 8 && x.ReservationDate.Year == DateTime.Now.Year && x.Status == 2).Count();
            var sep = annual.Where(x => x.ReservationDate.Month == 9 && x.ReservationDate.Year == DateTime.Now.Year && x.Status == 2).Count();
            var oct = annual.Where(x => x.ReservationDate.Month == 10 && x.ReservationDate.Year == DateTime.Now.Year && x.Status == 2).Count();
            var nov = annual.Where(x => x.ReservationDate.Month == 11 && x.ReservationDate.Year == DateTime.Now.Year && x.Status == 2).Count();
            var dec = annual.Where(x => x.ReservationDate.Month == 12 && x.ReservationDate.Year == DateTime.Now.Year && x.Status == 2).Count();

            var model = new DashboardViewModel()
            {
                CancelPercent = cancelReservation.Count() / (double)annual.Count() * 100,
                SuccessPercent = successReservation.Count() / (double)annual.Count() * 100,
                NewReservation = newReservation.Count(),
                ReservationAnnual = annual.Count(),
                ReservationMonthly = monthly.Count(),
                Jan = jan,
                Feb = feb,
                Mar = mar,
                Apr = apr,
                May = may,
                Jun = jun,
                Jul = jul,
                Aug = aug,
                Sep = sep,
                Oct = oct,
                Nov = nov,
                Dec = dec
            };

            return View(model);
        }
    }
}