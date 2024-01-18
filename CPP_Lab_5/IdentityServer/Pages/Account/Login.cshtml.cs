using Duende.IdentityServer.Extensions;
using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IdentityServer.Pages.Account;


public class LoginModel(
    Context context,
    SignInManager<User> signInManager
) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public required GetModel Get { get; init; }

    [BindProperty]
    public required PostModel Post { get; init; }

    [BindProperty(SupportsGet = true)]
    public string? ReturnUrl { get; init; }

    public ViewModel View { get; private set; } = null!;


    public IActionResult OnGet()
    {
        if (User.IsAuthenticated())
        {
            return RedirectToPage("/Index");
        }
        View = Get.ToView();
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (User.IsAuthenticated())
        {
            return RedirectToPage("/Index");
        }
        if (!ModelState.IsValid)
        {
            View = Post.ToView();
            return Page();
        }

        var user = await context.Users
            .AsNoTracking()
            .Where(u => u.Email == Post.Email)
            .FirstOrDefaultAsync();
        if (user is not null)
        {
            var result = await signInManager.CheckPasswordSignInAsync(
                user,
                Post.Password,
                lockoutOnFailure: false
            );
            if (result.Succeeded)
            {

                await signInManager.SignInWithClaimsAsync(
                    user,
                    isPersistent: true,
                    new Claim[]
                    {
                        new("full_name", user.FullName)
                    }
                );
                return Post.ReturnUrl is null
                    ? RedirectToPage("/Index")
                    : Redirect(Post.ReturnUrl);
            }
        }

        ModelState.AddModelError("", "Data is incorrect.");
        View = Post.ToView();
        return Page();
    }


    public class GetModel
    {
        public string? ReturnUrl { get; init; }


        public ViewModel ToView() => new()
        {
            ReturnUrl = ReturnUrl
        };
    }


    public class PostModel
    {
        public required string Email { get; init; }

        public required string Password { get; init; }

        public string? ReturnUrl { get; init; }


        public ViewModel ToView() => new()
        {
            Email = Email,
            Password = Password,
            ReturnUrl = ReturnUrl
        };
    }


    public class ViewModel
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}