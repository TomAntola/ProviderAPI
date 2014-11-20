using System.Web.Http;

namespace Web.Inbound
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Resource Routes
            config.Routes.MapHttpRoute(
                name: "Vehicle",
                routeTemplate: "vehicle/{provider}/{company}/{carNo}",
                defaults: new { controller = "Vehicle", company = RouteParameter.Optional, carNo = RouteParameter.Optional }
            );
        }
    }
}
