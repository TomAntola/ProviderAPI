using System.Web.Http;

namespace Web.Inbound
{
    public static class WebApiRouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Vehicle Route
            config.Routes.MapHttpRoute(
                name: "Vehicle",
                routeTemplate: "vehicle/{provider}/{company}/{carNo}",
                defaults: new { controller = "Vehicle", company = string.Empty, carNo =  string.Empty }
            );
        }
    }
}
