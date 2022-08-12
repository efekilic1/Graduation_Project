using System;
using System.Net;
using Business.Configuration.Filters.Logs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Business.Configuration.Filters.Exeption
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //veri tabanına loglanabiliriz
            //mail atabiliriz

            var msLogger = (context.HttpContext.RequestServices.GetService(typeof(MsSqlLogger))) as MsSqlLogger;

            var jsonResult = new JsonResult(
                new
                {
                    error = context.Exception.Message,
                    innerException = context.Exception.InnerException,
                    statusCode = HttpStatusCode.InternalServerError
                }

                );

            msLogger.LoggerManager.Error(jsonResult.Value.ToString());

            context.Result = jsonResult;

            base.OnException(context);
        }
    }
}
