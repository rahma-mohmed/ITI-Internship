using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ITIMVCD2.CustomActionFilter
{
    public class ExceptionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new ContentResult()
                {
                    Content = $"Exception Occured : {context.Exception.Message}"
                };
            }
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.Write("Action Start!!");
            base.OnActionExecuting(context);
        }
    }
}
