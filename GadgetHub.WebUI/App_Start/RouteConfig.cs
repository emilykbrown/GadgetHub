using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GadgetHub.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: null, "", new
                {
                    controller = "Gadget",
                    action = "List",
                    GadgetCategory = (string) null,
                    page = 1
                });

            routes.MapRoute(null, "Page{page}", new

            {
                controller = "Gadget",
                action = "List",
                GadgetCategory = (string) null,
            },
            new {page = @"\d+"});

            routes.MapRoute(null, "{GadgetCategory}", new
            {
                controller = "Gadget",
                action = "List",
                GadgetCategory = (string)null,
                page = 1
            });

            routes.MapRoute(null, "{GadgetCategory}/Page{page}", new

            {
                controller = "Gadget",
                action = "List",
            },
            
            new { page = @"\d+" });

            routes.MapRoute(null, "{controller}/{action}");

        }
    }
}
