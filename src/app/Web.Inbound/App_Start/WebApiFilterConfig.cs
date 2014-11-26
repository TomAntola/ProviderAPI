using System.Web.Http;
using Web.Inbound.Common.FiltersAndAttributes;

namespace Web.Inbound
{
    public class WebApiFilterConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new ExceptionFilter());
        }
    }
}
