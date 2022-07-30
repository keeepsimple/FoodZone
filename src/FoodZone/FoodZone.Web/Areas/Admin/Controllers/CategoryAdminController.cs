using FoodZone.Models.Common;
using FoodZone.Services.IServices;
using FoodZone.Web.Areas.Admin.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Areas.Admin.Controllers
{
    public class CategoryAdminController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IFoodServices _foodServices;

        public CategoryAdminController(ICategoryServices categoryServices, IFoodServices foodServices)
        {
            _categoryServices = categoryServices;
            _foodServices = foodServices;
        }

        
    }
}