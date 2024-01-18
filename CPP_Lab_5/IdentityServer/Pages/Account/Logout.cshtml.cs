using Duende.IdentityServer.Services;
using IdentityServer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServer.Pages.Account;


[Authorize]
public class LogoutModel(
    IIdentityServerInteractionService interactionService,
    SignInManager<User> signInManager
) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public required GetModel Get { get; init; }


    public async Task<IActionResult> OnGet()
    {
        var context = await interactionService.GetLogoutContextAsync(Get.LogoutId);
        await signInManager.SignOutAsync();
        return context?.PostLogoutRedirectUri is null
            ? RedirectToPage("/Index")
            : Redirect(context.PostLogoutRedirectUri);
    }


    public class GetModel
    {
        public string? LogoutId { get; init; }
    }
}