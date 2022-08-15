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
    public class NewsAdminController : Controller
    {
        private readonly INewsServices _newsServices;

        public NewsAdminController(INewsServices newServices)
        {
            _newsServices = newServices;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var news = await _newsServices.GetAllAsync();
            return View(news);
        }

        public ActionResult Create()
        {
            var newsViewModel = new NewsViewModel();
            return View(newsViewModel);
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        [ValidateInput(false)]
        public async Task<ActionResult> Create(NewsViewModel model, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";

                if (uploadImage != null)
                {
                    fileName = Path.GetFileName(uploadImage.FileName);
                    string folderPath = Path.Combine(Server.MapPath("~/assets/images"), uploadImage.FileName);
                    uploadImage.SaveAs(folderPath);
                }

                model.Image = fileName;

                var news = new News
                {
                    Title = model.Title,
                    Content = model.Content,
                    Image = model.Image,
                    ShortDescription = model.ShortDescription
                };

                var result = await _newsServices.AddAsync(news);

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

            var news = _newsServices.GetById((int)id);

            if (news == null)
            {
                return HttpNotFound();
            }

            var model = new NewsViewModel()
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                Image = news.Image,
                ShortDescription = news.ShortDescription
            };

            return View(model);
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        [ValidateInput(false)]
        public async Task<ActionResult> Edit(NewsViewModel model, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";

                if (uploadImage != null && uploadImage.ContentLength > 0)
                {
                    fileName = Path.GetFileName(uploadImage.FileName);
                    string folderPath = Path.Combine(Server.MapPath("~/assets/images"), uploadImage.FileName);
                    uploadImage.SaveAs(folderPath);
                }

                if (!string.IsNullOrEmpty(fileName))
                {
                    model.Image = fileName;
                }

                var news = _newsServices.GetById(model.Id);
                if(news == null)
                {
                    return HttpNotFound();
                }

                news.Title = model.Title;
                news.ShortDescription = model.ShortDescription;
                news.Content = model.Content;
                news.Image = model.Image;

                var result = await _newsServices.UpdateAsync(news);

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

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var result = _newsServices.Delete(id);

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