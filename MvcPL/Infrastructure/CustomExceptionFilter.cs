using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Infrastructure
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled)
            {
                ViewResult viewResult = new ViewResult();
                viewResult.ViewName = "ExceptionFound";
                exceptionContext.Result = viewResult;
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}