using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Account;


[Authorize]
public class LogoutModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public required GetModel Get { get; init; }


    public IActionResult OnGet() => SignOut(
        new AuthenticationProperties
        {
            RedirectUri = Get.ReturnUrl
        },
        CookieAuthenticationDefaults.AuthenticationScheme,
        OpenIdConnectDefaults.AuthenticationScheme
    );


    public class GetModel
    {
        public string? ReturnUrl { get; init; }
    }
}