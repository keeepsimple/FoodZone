using FoodZone.Web.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Controllers
{
    public class DashboardController : Controller
    {
        //public DashboardController(UserManager userManager, ApplicationSignInManager signInManager)
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}

        //private UserManager _userManager;
        //public UserManager UserManager
        //{
        //    get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
        //    private set => _userManager = value;
        //}

        //private ApplicationSignInManager _signInManager;

        //public ApplicationSignInManager SignInManager
        //{
        //    get => _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        //    private set => _signInManager = value;
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    // This doesn't count login failures towards lockout only two factor authentication
        //    // To enable password failures to trigger lockout, change to shouldLockout: true
        //    var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, shouldLockout: false);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
        //            return RedirectToAction("Index", "Dashboard");
        //        case SignInStatus.LockedOut:
        //            return View("Lockout");
        //        case SignInStatus.RequiresVerification:
        //            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
        //        case SignInStatus.Failure:
        //        default:
        //            ModelState.AddModelError("", "Invalid login attempt.");
        //            return View(model);
        //    }
        //}
    }
}