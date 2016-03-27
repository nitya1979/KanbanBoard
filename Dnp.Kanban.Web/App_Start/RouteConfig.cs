using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dnp.Kanban.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AuthTemplates",
                url: "Template/GetAuthTemplate/{template}",
                defaults: new { controller = "Template", action = "GetAuthTemplate", template = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "LoginTemplate",
                url: "Template/GetTemplate/{template}",
                defaults: new { controller = "Template", action = "GetTemplate", template = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Stages",
                url: "api/Project/Stages/{projectId}",
                defaults: new { controller = "Project", action = "Stages", projectId = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
