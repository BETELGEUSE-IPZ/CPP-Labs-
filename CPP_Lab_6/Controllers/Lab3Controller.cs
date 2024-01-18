using lab6.Data;
using lab6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers
{
    [Controller]
    [Authorize]
    public class Lab3Controller : Controller
    {
        private ApiDataSource apiDataSource;

        public Lab3Controller(ApiDataSource apiDataSource)
        {
            this.apiDataSource = apiDataSource;
        }

        public IActionResult Lab3()
        {
            return View(new LabModel());
        }

        [HttpPost]
        public IActionResult Lab3(LabModel model)
        {
            string outputText = apiDataSource.ExecuteLab3(model.Input).Result;
            model.Output = outputText;
            return View(model);
        }
    }
}
