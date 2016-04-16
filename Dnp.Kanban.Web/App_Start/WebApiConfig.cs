using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using Dnp.Kanban.Domain;
using Dnp.Kanban.SqlRepository;
using System.Web.Mvc;
using System.Web.Http.Controllers;
using Dnp.Kanban.Web.Controllers;
using Dnp.Kanban.Web.Filters;

namespace Dnp.Kanban.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Filters.Add(new DnpHandleErrorAttribute());
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            var _unityContainer = new UnityContainer();
            _unityContainer.RegisterType<IProjectRepository, SqlProjectRepository>( new InjectionConstructor( "DefaultConnection"));
            _unityContainer.RegisterType<IHttpController, ProjectController>();

            config.DependencyResolver = new UnityResolover(_unityContainer);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
