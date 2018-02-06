using LAP_PowerMining.Core.Authorization;
using LAP_PowerMining.Core.Controllers;
using LAP_PowerMining.Core.Enums;
using LAP_PowerMining.Core.Services;
using LAP_PowerMining.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAP_PowerMining.Controllers
{
    public class AccountController : MyBaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            if (TempData["LoginSuccess"] != null && (bool)TempData["LoginSuccess"] == true)
            {
                TempData["LoginSuccess"] = null;
                this.AddToastMessage("Welcome", "You are logged in!", ToastType.Success);
            }
            if (TempData["RegisterSuccess"] != null && (bool)TempData["RegisterSuccess"] == true)
            {
                TempData["RegisterSuccess"] = null;
                this.AddToastMessage("Welcome", "You are registered and logged in!", ToastType.Success);
            }
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            TempData["LoggedOut"] = true;
            AccountService.LogOutUser();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Login(VMLogin loginInfo)
        {
            if (ModelState.IsValid)
            {
                bool result = AccountService.LogInUser(loginInfo);
                if (result == true)
                {
                    ViewBag.LoggedIn = true;
                    TempData["LoginSuccess"] = true;
                }
                else
                {
                    TempData["LoginSuccess"] = false;
                    ViewBag.ErrorMessage = "Password or email incorrect...";
                }
            }
            return PartialView("_LoginForm", loginInfo);
        }
        [HttpPost]
        public ActionResult Register(VMRegister registInfo)
        {
            if (ModelState.IsValid)
            {
                int result = AccountService.RegisterUser(registInfo);
                switch (result)
                {
                    case (int)RegisterType.Success:
                        ViewBag.LoggedIn = true;
                        TempData["RegisterSuccess"] = true;
                        break;
                    case (int)RegisterType.PasswordsDifferent:
                        ViewBag.ErrorMessage = "Passwords not equal";
                        break;
                    case (int)RegisterType.UserExisting:
                        ViewBag.ErrorMessage = "User existing!";
                        break;
                    case (int)RegisterType.Error:
                        ViewBag.ErrorMessage = "Error occured, please try again later!";
                        break;
                }
            }
            return PartialView("_RegisterForm", registInfo);
        }
        [Authorize]
        public ActionResult Verification()
        {

            return View("Verification");
        }
        [HttpGet]
        [Authorize]
        public ActionResult PersonalData()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditAddress(VMAddress addressData)
        {
            addressData.UserEmail = User.Identity.Name;
            int result = -1;
            if (ModelState.IsValid)
            {
                result = AddressService.UpdateAddress(addressData);
            }
            switch (result)
            {
                case 0:
                    ViewBag.AddressMessage = "Updated successfully!";
                    break;
                default:
                    ViewBag.ErrorMessage = "Error occured..";
                    break;
            }

            return PartialView("_AddressForm", addressData);
        }

        #region Autocompletes
        [HttpPost]
        [Authorize]
        public JsonResult AutoCompleteCities(string searchTerm)
        {
            List<VMCity> result = AddressService.GetCities(searchTerm);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Authorize]
        public JsonResult AutoCompleteCountries(string searchTerm)
        {
            List<VMCountry> result = AddressService.GetCountries(searchTerm);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}