using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace demo01.Controllers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UserAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var result = context.HttpContext.Session.GetString("userId")??string.Empty;
            if(string.IsNullOrEmpty(result))
            {
                throw new UnauthorizedAccessException("Giriş işlemi başarısız!");
            }         
            base.OnActionExecuting(context);
        }
    }
}
