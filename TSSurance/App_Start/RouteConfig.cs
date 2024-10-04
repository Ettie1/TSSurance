using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TSSurance
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Splash",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Splash", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Policyholder",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Policyholder", action = "PolicyholderMenu", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Menu",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Menu", action = "MainMenu", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
