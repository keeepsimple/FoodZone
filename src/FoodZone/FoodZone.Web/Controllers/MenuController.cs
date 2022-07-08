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

        public ActionResult GetAllMenu()
        {
            var menu = _menuServices.GetAll();
            return PartialView("_GetAllMenu",menu);
        }

        public ActionResult Details(int menuId)
        {
            var menu = _menuServices.GetById(menuId);
            if(menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.Menu = menu.Name;
            var categories = _categoryServices.GetCategoryByMenu(menuId);
            
            return View(categories);
        }

        public ActionResult GetFoodByCate(int cateId)
        {
            var foods = _foodServices.GetFoodsByCategory(cateId);
            return PartialView("_FoodByCate", foods);
        }
    }
}