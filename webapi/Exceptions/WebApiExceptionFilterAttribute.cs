using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using log4net;

namespace webapi.Exceptions
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exception = actionExecutedContext.Exception;//获取产生的异常对象
            var exceptionMessage = exception.Message;
            var logMessage = 
                $@"controller.action={actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName}.{actionExecutedContext.ActionContext.ActionDescriptor.ActionName}:exception="
                + exception.Message;//异常内容
            ILog log = LogManager.GetLogger(actionExecutedContext.ActionContext.ControllerContext.Controller.GetType());
            if (exception is KnownException)
            {
                log.Debug(logMessage);
            }
            else
            {
                log.Error(logMessage, exception);
            }
            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, exceptionMessage);
        }

    }
}