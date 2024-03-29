﻿using FoodZone.Models.Security;
using FoodZone.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodZone.Web.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        public ManageController()
        {
        }

        public ManageController(UserManager userManager)
        {
            UserManager = userManager;
        }

        private UserManager _userManager;
        public UserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>();
            private set => _userManager = value;
        }

        //
        // GET: /Account/Index
        [HttpGet]
        public ActionResult Index()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var accountDetail = new AccountDetailViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Username = user.UserName,
                Level = user.Level,
                PhoneNumber = user.PhoneNumber
            };
            return View(accountDetail);
        }

        [HttpPost]
        public ActionResult Index(AccountDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindById(model.UserId);
                user.FullName = model.FullName;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;

                var result = UserManager.Update(user);
                if (result.Succeeded)
                {
                    TempData["Message"] = "Cập nhật thành công.";
                    return RedirectToAction("Index", "Manage");
                }
                else
                {
                    TempData["Message"] = "Cập nhật thất bại";
                }
            }
            return View(model);
        }

        #region no use
        ////
        //// GET: /Account/RemoveLogin
        //[HttpGet]
        //public ActionResult RemoveLogin()
        //{
        //    var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
        //    ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
        //    return View(linkedAccounts);
        //}

        ////
        //// POST: /Manage/RemoveLogin
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        //{
        //    ManageMessageId? message;
        //    var userId = User.Identity.GetUserId();
        //    var result = await UserManager.RemoveLoginAsync(userId, new UserLoginInfo(loginProvider, providerKey));
        //    if (result.Succeeded)
        //    {
        //        var user = await UserManager.FindByIdAsync(userId);
        //        if (user != null)
        //        {
        //            await SignInAsync(user, isPersistent: false);
        //        }
        //        message = ManageMessageId.RemoveLoginSuccess;
        //    }
        //    else
        //    {
        //        message = ManageMessageId.Error;
        //    }
        //    return RedirectToAction("ManageLogins", new { Message = message });
        //}

        ////
        //// GET: /Account/AddPhoneNumber
        //[HttpGet]
        //public ActionResult AddPhoneNumber()
        //{
        //    return View();
        //}

        ////
        //// POST: /Account/AddPhoneNumber
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    // Generate the token and send it
        //    var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
        //    if (UserManager.SmsService != null)
        //    {
        //        var message = new IdentityMessage
        //        {
        //            Destination = model.Number,
        //            Body = "Your security code is: " + code
        //        };
        //        await UserManager.SmsService.SendAsync(message);
        //    }
        //    return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        //}

        ////
        //// POST: /Manage/RememberBrowser
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult RememberBrowser()
        //{
        //    var rememberBrowserIdentity = AuthenticationManager.CreateTwoFactorRememberBrowserIdentity(User.Identity.GetUserId());
        //    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, rememberBrowserIdentity);
        //    return RedirectToAction("Index", "Manage");
        //}

        ////
        //// POST: /Manage/ForgetBrowser
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ForgetBrowser()
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        //    return RedirectToAction("Index", "Manage");
        //}

        ////
        //// POST: /Manage/EnableTFA
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EnableTFA()
        //{
        //    var userId = User.Identity.GetUserId();
        //    await UserManager.SetTwoFactorEnabledAsync(userId, true);
        //    var user = await UserManager.FindByIdAsync(userId);
        //    if (user != null)
        //    {
        //        await SignInAsync(user, isPersistent: false);
        //    }
        //    return RedirectToAction("Index", "Manage");
        //}

        ////
        //// POST: /Manage/DisableTFA
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DisableTFA()
        //{
        //    var userId = User.Identity.GetUserId();
        //    await UserManager.SetTwoFactorEnabledAsync(userId, false);
        //    var user = await UserManager.FindByIdAsync(userId);
        //    if (user != null)
        //    {
        //        await SignInAsync(user, isPersistent: false);
        //    }
        //    return RedirectToAction("Index", "Manage");
        //}

        ////
        //// GET: /Account/VerifyPhoneNumber
        //[HttpGet]
        //public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        //{
        //    // This code allows you exercise the flow without actually sending codes
        //    // For production use please register a SMS provider in IdentityConfig and generate a code here.
        //    var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
        //    ViewBag.Status = "For DEMO purposes only, the current code is " + code;
        //    return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        //}

        ////
        //// POST: /Account/VerifyPhoneNumber
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var userId = User.Identity.GetUserId();
        //    var result = await UserManager.ChangePhoneNumberAsync(userId, model.PhoneNumber, model.Code);
        //    if (result.Succeeded)
        //    {
        //        var user = await UserManager.FindByIdAsync(userId);
        //        if (user != null)
        //        {
        //            await SignInAsync(user, isPersistent: false);
        //        }
        //        return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
        //    }
        //    // If we got this far, something failed, redisplay form
        //    ModelState.AddModelError("", "Failed to verify phone");
        //    return View(model);
        //}

        ////
        //// GET: /Account/RemovePhoneNumber
        //[HttpGet]
        //public async Task<ActionResult> RemovePhoneNumber()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var result = await UserManager.SetPhoneNumberAsync(userId, null);
        //    if (!result.Succeeded)
        //    {
        //        return RedirectToAction("Index", new { Message = ManageMessageId.Error });
        //    }
        //    var user = await UserManager.FindByIdAsync(userId);
        //    if (user != null)
        //    {
        //        await SignInAsync(user, isPersistent: false);
        //    }
        //    return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        //}
        #endregion
        //
        // GET: /Manage/ChangePassword
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = User.Identity.GetUserId();
            var result = await UserManager.ChangePasswordAsync(userId, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(userId);
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        #region no use

        ////
        //// GET: /Manage/SetPassword
        //[HttpGet]
        //public ActionResult SetPassword()
        //{
        //    return View();
        //}

        ////
        //// POST: /Manage/SetPassword
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userId = User.Identity.GetUserId();
        //        var result = await UserManager.AddPasswordAsync(userId, model.NewPassword);
        //        if (result.Succeeded)
        //        {
        //            var user = await UserManager.FindByIdAsync(userId);
        //            if (user != null)
        //            {
        //                await SignInAsync(user, isPersistent: false);
        //            }
        //            return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
        //        }
        //        AddErrors(result);
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        ////
        //// GET: /Account/Manage
        //public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        //{
        //    ViewBag.StatusMessage =
        //        message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
        //        : message == ManageMessageId.Error ? "An error has occurred."
        //        : "";
        //    var userId = User.Identity.GetUserId();
        //    var user = await UserManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        return View("Error");
        //    }
        //    var userLogins = await UserManager.GetLoginsAsync(userId);
        //    var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
        //    ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
        //    return View(new ManageLoginsViewModel
        //    {
        //        CurrentLogins = userLogins,
        //        OtherLogins = otherLogins
        //    });
        //}

        ////
        //// POST: /Manage/LinkLogin
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LinkLogin(string provider)
        //{
        //    // Request a redirect to the external login provider to link a login for the current user
        //    return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        //}

        ////
        //// GET: /Manage/LinkLoginCallback
        //public async Task<ActionResult> LinkLoginCallback()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, userId);
        //    if (loginInfo == null)
        //    {
        //        return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        //    }
        //    var result = await UserManager.AddLoginAsync(userId, loginInfo.Login);
        //    return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        //}
        #endregion

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        private async Task SignInAsync(User user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion
    }
}