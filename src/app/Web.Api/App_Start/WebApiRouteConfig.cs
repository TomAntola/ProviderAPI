using System.Web.Http;

namespace Web.Api
{
    public static class WebApiRouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Vehicle Route
            config.Routes.MapHttpRoute(
                name: "Vehicle",
                routeTemplate: "vehicle/{company}/{carNo}",
                defaults: new { controller = "Vehicle" }
            );
        }
    }
}
