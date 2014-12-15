using System.Web.Http;
using Web.Api.Common.FiltersAndAttributes;

namespace Web.Api
{
    public class WebApiFilterConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new ExceptionFilter());
        }
    }
}
