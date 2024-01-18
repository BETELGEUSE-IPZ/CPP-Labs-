using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WebApp.Pages.Account;


[Authorize]
public class AboutModel : PageModel
{
    public ViewModel View { get; private set; } = null!;


    public void OnGet()
    {
        View = new()
        {
            UserName = User.FindFirstValue("name"),
            FullName = User.FindFirstValue("full_name"),
            PhoneNumber = User.FindFirstValue("phone_number"),
            Email = User.FindFirstValue("email")
        }; ;
    }


    public class ViewModel
    {
        public string? UserName { get; set; }

        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}