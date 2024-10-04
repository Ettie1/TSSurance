using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TSSurance.Controllers
{
    public class SplashController : Controller
    {
        // GET: Splash
        public ActionResult Index()
        {
            TempData["success"] = "TSSurance";
            ViewBag.Title = "TSSUrance";
            ViewBag.Message = "Welcome TECHIESPirals";
            return View();
        }
    }
}