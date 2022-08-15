using FoodZone.Services.IServices;
using FoodZone.Web.Areas.Admin.ViewModels;
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
            var cancelReservation = annual.Where(x => x.Status == 4);
            var successReservation = annual.Where(x => x.Status == 3);

            var model = new DashboardViewModel()
            {
                CancelPercent = cancelReservation.Count() / (double)annual.Count() * 100,
                SuccessPercent = successReservation.Count() / (double)annual.Count() * 100,
                NewReservation = newReservation.Count(),
                ReservationAnnual = annual.Count(),
                ReservationMonthly = monthly.Count()
            };

            return View(model);
        }
    }
}