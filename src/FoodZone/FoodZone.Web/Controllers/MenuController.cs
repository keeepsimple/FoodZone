using FoodZone.Services.IServices;
using System.Web.Mvc;

namespace FoodZone.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuServices _menuServices;
        private readonly IFoodServices _foodServices;
        private readonly ICategoryServices _categoryServices;

        public MenuController(IMenuServices menuServices, IFoodServices foodServices, ICategoryServices categoryServices)
        {
            _menuServices = menuServices;
            _foodServices = foodServices;
            _categoryServices = categoryServices;
        }

        public ActionResult GetAll()
        {
            var menu = _menuServices.GetAll();
            return View(menu);
        }

        public ActionResult GetCategoryByMenu(int menuId)
        {
            var categories = _categoryServices.GetCategoryByMenu(menuId);
            return PartialView("_GetCategoryByMenu", categories);
        }

        public ActionResult GetFoodByCate(int cateId)
        {
            var foods = _foodServices.GetFoodsByCategory(cateId);
            return PartialView("_FoodByCate", foods);
        }
    }
}