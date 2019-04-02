using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using REZAPIInventory.TokenHandlers;

namespace REZAPIInventory
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new TokenHandler());

            config.Routes.MapHttpRoute(
 name: "API Default",
 routeTemplate: "api/{controller}/{action}/{id}",
 defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
