using Duende.IdentityServer.Extensions;
using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Pages.Account;


public class RegisterModel(UserManager<User> userManager) : PageModel
{
    [BindProperty]
    public required PostModel Post { get; init; }

    public ViewModel View { get; private set; } = null!;


    public IActionResult OnGet()
    {
        if (User.IsAuthenticated())
        {
            return RedirectToPage("/Index");
        }
        View = new();
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

        var result = await userManager.CreateAsync(
            new()
            {
                UserName = Post.UserName,
                FullName = Post.FullName,
                PhoneNumber = Post.PhoneNumber,
                Email = Post.Email
            },
            Post.Password
        );
        if (result.Succeeded)
        {
            return RedirectToPage("/Index");
        }
        foreach (var error in result.Errors)
        {
            ModelState.TryAddModelError("", error.Description);
        }
        View = Post.ToView();
        return Page();
    }


    public class PostModel
    {
        [MaxLength(50)]
        public required string UserName { get; init; }

        [MaxLength(500)]
        public required string FullName { get; init; }

        [Length(8, 16)]
        public required string Password { get; init; }

        [Compare(nameof(Password))]
        public required string ConfirmationPassword { get; init; }

        [RegularExpression(
            @"\+380\d{9}",
            ErrorMessage = "Invalid Ukrainian phone number."
        )]
        public required string PhoneNumber { get; init; }

        [EmailAddress]
        public required string Email { get; init; }


        public ViewModel ToView() => new()
        {
            UserName = UserName,
            FullName = FullName,
            Password = Password,
            ConfirmationPassword = ConfirmationPassword,
            PhoneNumber = PhoneNumber,
            Email = Email
        };
    }


    public class ViewModel
    {
        public string? UserName { get; set; }

        public string? FullName { get; set; }

        public string? Password { get; set; }

        public string? ConfirmationPassword { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}