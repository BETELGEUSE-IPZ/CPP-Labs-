using lab6.Data;
using lab6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers
{
    [Controller]
    [Authorize]
    public class Lab2Controller : Controller
    {
        private ApiDataSource apiDataSource;

        public Lab2Controller(ApiDataSource apiDataSource)
        {
            this.apiDataSource = apiDataSource;
        }

        public IActionResult Lab2()
        {
            return View(new LabModel());
        }

        [HttpPost]
        public IActionResult Lab2(LabModel model)
        {
            string outputText = apiDataSource.ExecuteLab2(model.Input).Result;
            model.Output = outputText;
            return View(model);
        }
    }
}
