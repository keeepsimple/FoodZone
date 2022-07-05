using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using FoodZone.Web.Areas.Admin.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Manager")]
    public class BlogAdminController : Controller
    {
        private readonly IBlogServices _blogServices;

        public BlogAdminController(IBlogServices blogServices)
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

        public ActionResult Create()
        {
            var blogViewModel = new BlogViewModel();
            return View(blogViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(BlogViewModel model)
        {
            if (ModelState.IsValid)
            {

                var blog = new Blog
                {
                    Title = model.Title,
                    Content = model.Content,
                    Image = model.Image,
                    ShortDescription = model.ShortDescription
                };

                var result = await _blogServices.AddAsync(blog);
                if (result > 0)
                {
                    TempData["Message"] = "Tạo thành công.";
                }
                else
                {
                    TempData["Message"] = "Tạo thất bại. Thử lại sao nhé!";
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var blog = _blogServices.GetById((int)id);

            if (blog == null)
            {
                return HttpNotFound();
            }

            var blogViewModel = new BlogViewModel()
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                Image = blog.Image,
                ShortDescription = blog.ShortDescription
            };

            return View(blogViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(BlogViewModel blogViewModel)
        {
            if (ModelState.IsValid)
            {

                var blog = _blogServices.GetById(blogViewModel.Id);
                if(blog == null)
                {
                    return HttpNotFound();
                }

                blog.Title = blogViewModel.Title;
                blog.ShortDescription = blogViewModel.ShortDescription;
                blog.Content = blogViewModel.Content;
                blog.Image = blogViewModel.Image;

                var result = await _blogServices.UpdateAsync(blog);

                if (result)
                {
                    TempData["Message"] = "Cập nhật thành công.";
                }
                else
                {
                    TempData["Message"] = "Cập nhật thất bại.";
                }
                return RedirectToAction("Index");
            }
            return View(blogViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var result = _blogServices.Delete(id);
            if (result)
            {
                TempData["Message"] = "Xóa thành công.";
            }
            else
            {
                TempData["Message"] = "Xóa thất bại.";
            }
            return RedirectToAction("Index");
        }
    }
}