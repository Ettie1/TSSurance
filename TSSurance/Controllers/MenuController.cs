using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TSSurance.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MainMenu()
        {
            ViewBag.Title = "Main Menu";
            ViewBag.Message = "Please choose an option below.";
            return View();
        }
    }
}