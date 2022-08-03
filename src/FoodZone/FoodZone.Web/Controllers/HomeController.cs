using FoodZone.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsServices _newsServices;

        public HomeController(INewsServices newsServices)
        {
            _newsServices = newsServices;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLastestNews()
        {
            var news = _newsServices.GetAll().OrderByDescending(x => x.InsertedAt).Take(3);
            return PartialView("_HomeNews", news);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}