using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebQLHS.Models.Authentication
{
    public class CheckRoleAdmin: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Role") != "User")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Area", "Admin" }, { "Controller", "HomeAdmin" }, { "Action", "Index" } });
            }
        }
    }
}
