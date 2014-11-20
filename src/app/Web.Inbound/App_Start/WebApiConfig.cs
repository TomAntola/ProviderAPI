using System.Web.Http;
using Web.Inbound.Common.FiltersAndAttributes;

namespace Web.Inbound
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Global Filters
            config.Filters.Add(new ExceptionFilter());

            // Vehicle Route
            config.Routes.MapHttpRoute(
                name: "Vehicle",
                routeTemplate: "vehicle/{provider}/{company}/{carNo}",
                defaults: new { controller = "Vehicle", company = string.Empty, carNo =  string.Empty }
            );
        }
    }
}
