using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;

namespace lab6.Controllers
{
    [Controller]
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }

            return RedirectToAction("Profile", "Profile");
        }

        public IActionResult LogOut()
        {
            return new SignOutResult(
                new[]
                {
                    OktaDefaults.MvcAuthenticationScheme,
                    CookieAuthenticationDefaults.AuthenticationScheme
                },
                new Microsoft.AspNetCore.Authentication.AuthenticationProperties() { RedirectUri = "/Home/Index" }
            );
        }
    }
}
