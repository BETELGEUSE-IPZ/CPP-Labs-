using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
