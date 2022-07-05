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
    public class BlogController:Controller
    {
        private readonly IBlogServices _blogServices;

        public BlogController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
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

            var blogs = await _blogServices.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                blogs = blogs.Where(s => s.Title.Contains(searchString)).ToList();
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(blogs.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int blogId)
{
            var blog = _blogServices.GetById(blogId);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.Blog = blog.Title;
            return View(blog);
        }
    }
}