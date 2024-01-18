using lab6.Data;
using lab6.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers
{
    public class CountryCodeController : Controller
    {
        private readonly ApiDataSource apiDataSource;

        public CountryCodeController(ApiDataSource apiDataSource) {
            this.apiDataSource = apiDataSource;
        }

        public IActionResult CountryCode()
        {
            var list = apiDataSource.GetISOCountryCodesAsync().Result;
            return View(
                new CountryCodeModel
                {
                    ISOCountryCodes = list
                }
            );
        }

        [HttpPost]
        public IActionResult CountryCode(CountryCodeModel model)
        {
            var list = apiDataSource.GetISOCountryCodesAsync(model.CountryCodeToSearch).Result;
            return View(
                new CountryCodeModel
                {
                    ISOCountryCodes = list
                }
            );
        }
    }
}
