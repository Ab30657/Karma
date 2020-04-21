using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoeStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                url: "Store/{action}/{selectedCategory}/{selectedSubCategory}",
                defaults: new { controller = "Store", action = "Shop", selectedCategory = (string)null, selectedSubCategory = (string)null }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Store", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
