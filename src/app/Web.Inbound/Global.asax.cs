using System.Web.Http;

namespace Web.Inbound
{
    //TODO: Remove once IIS6 setup is documented and/or fully understood.
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApiRouteConfig.Register(GlobalConfiguration.Configuration);
            WebApiFilterConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}
