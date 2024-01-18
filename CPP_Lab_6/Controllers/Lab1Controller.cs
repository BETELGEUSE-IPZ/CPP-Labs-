using lab6.Data;
using lab6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers
{
    [Controller]
    [Authorize]
    public class Lab1Controller : Controller
    {
        private ApiDataSource apiDataSource;

        public Lab1Controller(ApiDataSource apiDataSource)
        {
            this.apiDataSource = apiDataSource;
        }

        public IActionResult Lab1()
        {
            return View(new LabModel());
        }

        [HttpPost]
        public IActionResult Lab1(LabModel model)
        {
            string outputText = apiDataSource.ExecuteLab1(model.Input).Result;
            model.Output = outputText;
            return View(model);
        }
    }
}
