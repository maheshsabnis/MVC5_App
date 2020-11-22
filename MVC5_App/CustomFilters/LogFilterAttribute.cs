using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
 
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC5_App.CustomFilters
{
    public class LogFilterAttribute : ActionFilterAttribute 
    {
        private void LogRequest(string requestState, RouteData route)
        {
            string controllerName = route.Values["controller"].ToString();
            string actionName = route.Values["action"].ToString();

            string logMessage = $"Current State {requestState} in controller {controllerName} in actoin {actionName}";
            Debug.WriteLine(logMessage);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogRequest("Action Executing", filterContext.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogRequest("Action Executed", filterContext.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            LogRequest("Result Executing", filterContext.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            LogRequest("Result Executed", filterContext.RouteData);
        }
    }
}