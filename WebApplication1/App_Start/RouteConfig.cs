using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "dd",
                 url: "{controller}/{action}/{id}",
                     defaults: new { controller = "home", action = "index" },
                      namespaces: new[] { "oidc.web.web.areas.admin.controllers" }//定位到其他area时，修改这里和datatokens

                ).DataTokens.Add("dd","dd");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
