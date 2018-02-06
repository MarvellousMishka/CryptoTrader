using LAP_PowerMining.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAP_PowerMining.Controllers
{
    public class MarketController : MyBaseController
    {
        // GET: Market
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}