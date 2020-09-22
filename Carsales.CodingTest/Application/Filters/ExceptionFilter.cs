using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Carsales.CodingTest.Application.Filters
{
    public class ExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception != null)
            {
                context.Result = new ObjectResult(new
                {
                    ExceptionMessage = context.Exception.Message,
                    InnerExceptionMessage = context.Exception.InnerException?.Message
                })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
