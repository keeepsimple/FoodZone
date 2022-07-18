using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsServices _newsServices;

        public NewsController(INewsServices newServices)
        {
            _newsServices = newServices;
        }

        [HttpGet]
        public async Task<ActionResult> Index(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var news = await _newsServices.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                news = news.Where(s => s.Title.Contains(searchString)).ToList();
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(news.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int newsId)
        {
            var news = _newsServices.GetById(newsId);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.News = news.Title;
            return View(news);
        }
    }
}