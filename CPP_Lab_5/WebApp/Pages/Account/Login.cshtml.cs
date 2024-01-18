using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Account;


public class LoginModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public required GetModel Get { get; init; }


    public IActionResult OnGet() => User.Identity?.IsAuthenticated is true
        ? RedirectToPage("/Index")
        : Challenge(new AuthenticationProperties
        {
            RedirectUri = Get.ReturnUrl
        });


    public class GetModel
    {
        public string? ReturnUrl { get; init; }
    }
}