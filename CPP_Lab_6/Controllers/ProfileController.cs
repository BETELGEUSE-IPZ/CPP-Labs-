using lab6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace lab6.Controllers
{
    [Controller]
    [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            return View(
                new ApplicationUser()
                {
                    Nickname = HttpContext.User.Claims.Where(x => x.Type == "nickname").FirstOrDefault()?.Value,
                    FirstName = HttpContext.User.Claims.Where(x => x.Type == "given_name").FirstOrDefault()?.Value,
                    LastName = HttpContext.User.Claims.Where(x => x.Type == "family_name").FirstOrDefault()?.Value,
                    MiddleName = HttpContext.User.Claims.Where(x => x.Type == "middle_name").FirstOrDefault()?.Value,
                    Email = HttpContext.User.Claims.Where(x => x.Type == "email").FirstOrDefault()?.Value,
                    PhoneNumber = HttpContext.User.Claims.Where(x => x.Type == "phone_number").FirstOrDefault()?.Value,   
                }
            );
        }
    }
}
