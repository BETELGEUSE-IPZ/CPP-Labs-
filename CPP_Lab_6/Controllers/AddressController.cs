using lab6.Data;
using lab6.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers
{
    public class AddressController : Controller
    {
        private readonly ApiDataSource apiDataSource;

        public AddressController(ApiDataSource apiDataSource)
        {
            this.apiDataSource = apiDataSource;
        }

        public IActionResult Address()
        {
            var list = apiDataSource.GetUKPAFFilesAsync().Result;
            return View(
                new AddressModel
                {
                    Files = list
                }
            );
        }

        [HttpPost]
        public IActionResult Address(AddressModel model)
        {
            var list = apiDataSource.GetUKPAFFilesAsync(model.IdToSearch).Result;
            return View(
                new AddressModel
                {
                    Files = list
                }
            );
        }
    }
}
