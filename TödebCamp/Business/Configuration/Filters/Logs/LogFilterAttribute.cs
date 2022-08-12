using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Configuration.Filters.Logs
{
    public class LogFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Logged successfully.");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var msLogger = context.HttpContext.RequestServices.GetService<MsSqlLogger>();
            var data = context.ActionArguments.Values;
            var logStr = System.Text.Json.JsonSerializer.Serialize(data);

            msLogger.LoggerManager.Information(logStr);

        }
    }
}
