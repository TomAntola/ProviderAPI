using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Web.Inbound
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Resource Routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
