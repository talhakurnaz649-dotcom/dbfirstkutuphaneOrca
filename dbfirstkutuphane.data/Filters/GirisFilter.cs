using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace dbfirstkutuphane.data.Filters
{
    public class GirisGerekliAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("Rol");
            if (string.IsNullOrEmpty(rol))
                context.Result = new RedirectToActionResult("Login", "Giris", null);
        }
    }

    public class AdminGerekliAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("Rol");
            if (rol != "Admin")
                context.Result = new RedirectToActionResult("Login", "Giris", null);
        }
    }
}