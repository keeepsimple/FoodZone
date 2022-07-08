using FoodZone.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Controllers
{
    public class FoodController:Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IFoodServices _foodServices;

        public FoodController(ICategoryServices categoryServices, IFoodServices foodServices)
        {
            _categoryServices = categoryServices;
            _foodServices = foodServices;
        }

        
    }
}