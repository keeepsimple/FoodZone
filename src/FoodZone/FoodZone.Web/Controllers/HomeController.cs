using FoodZone.Services.IServices;
using FoodZone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodZone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoodServices _foodServices;

        public HomeController(IFoodServices foodServices)
        {
            _foodServices = foodServices;
        }

        public async Task<IActionResult> Index()
        {
            var foods = await _foodServices.GetAllAsync();
            return View(foods);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}