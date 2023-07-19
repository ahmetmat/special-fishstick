using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace demo01.Controllers
{
    public class UserAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string role = context.HttpContext.User.FindFirst("roles")?.Value;
            int userId = Convert.ToInt32(context.HttpContext.User.FindFirst("id")?.Value);

            if (role == "Standard" && context.RouteData.Values.ContainsKey("id"))
            {
                int requestedId;
                if (!int.TryParse(context.RouteData.Values["id"].ToString(), out requestedId))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                if (requestedId != userId)
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }

            base.OnActionExecuting(context);
        }
    }
}

