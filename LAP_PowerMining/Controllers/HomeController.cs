using LAP_PowerMining.Core.Controllers;
using LAP_PowerMining.Models.ViewModels.Account;
using LAP_PowerMining.Core.Enums;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KrakenClient;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using System.Web.Script.Serialization;
using LAP_PowerMining.Core.KrakenComponents;
using System;

namespace LAP_PowerMining.Controllers
{
    
    public class HomeController : MyBaseController
    {
        public ActionResult Index()
        {           
            if (User.IsInRole("Admin"))
            {

            }
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {

                if (TempData["LoginSuccess"] != null && (bool)TempData["LoginSuccess"] == false)
                {
                    AddToastMessage("Danger!", "Login data wrong, please try again!", ToastType.Warning);
                    TempData["LoginSuccess"] = null;
                }
                else if (TempData["LoggedOut"] == null)
                {
                    AddToastMessage("Welcome!", "Please login to proceed", ToastType.Info);
                }
                else
                {
                    AddToastMessage("Why!?", "You have been logged out!", ToastType.Warning);
                    TempData["LoggedOut"] = null;
                }
                return View("Index");
            }
        }
    }
}