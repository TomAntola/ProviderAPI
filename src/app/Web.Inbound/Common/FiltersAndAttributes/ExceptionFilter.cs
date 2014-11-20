using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Filters;
//using log4net;

namespace Web.Inbound.Common.FiltersAndAttributes
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        // Retrieves the logger for the Web API.
        //private static readonly ILog log = LogManager.GetLogger("smtp.webapi-logger");

        public override void OnException(HttpActionExecutedContext context)
        {
            switch (context.Exception.GetType().Name)
            {
                case "BadRequestException":
                    LogExceptionContext(context, "Error");
                    context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError(context.Exception.GetBaseException().Message));
                    break;
                case "ConfigurationException":
                    LogExceptionContext(context, "Error");
                    context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(context.Exception.GetBaseException().Message));
                    break;
                case "ConflictException":
                    LogExceptionContext(context, "Debug");
                    context.Response = context.Request.CreateErrorResponse(HttpStatusCode.Conflict, new HttpError(context.Exception.GetBaseException().Message));
                    break;
                case "ForbiddenException":
                    LogExceptionContext(context, "Error");
                    context.Response = context.Request.CreateErrorResponse(HttpStatusCode.Forbidden, new HttpError(context.Exception.GetBaseException().Message));
                    break;
                case "NotFoundException":
                    LogExceptionContext(context, "Debug");
                    context.Response = context.Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError(context.Exception.GetBaseException().Message));
                    break;
                case "HttpResponseException":
                    // Let HttpResponseExceptions pass through.
                    LogExceptionContext(context, "Debug");
                    break;
                default:
                    LogExceptionContext(context, "Error");
                    context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError("An internal service error has occurred."));
                    break;
            }
        }

        private void LogExceptionContext(HttpActionExecutedContext context, string log_level)
        {
            var sb = new StringBuilder();

            foreach (var p in context.ActionContext.ControllerContext.RouteData.Values)
            {
                sb.Append("Key: ");
                sb.Append(p.Key);
                sb.Append(" Value: ");
                sb.Append(p.Value);
                sb.Append(" ");
            }


            switch (log_level)
            {
                case "Debug":
                    //log.Debug(sb.ToString(), context.Exception);
                    break;
                case "Error":
                    //log.Debug(sb.ToString(), context.Exception);
                    //log.Error(sb.ToString(), context.Exception);
                    break;
            }
        }
    }
}
