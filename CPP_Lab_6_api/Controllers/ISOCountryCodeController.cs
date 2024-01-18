using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("iso-country-codes")]
    public class ISOCountryCodeController : ControllerBase
    {
        private readonly DBContext context;

        public ISOCountryCodeController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ISOCountryCode>>> GetISOCountryCodes()
        {
            var countryCodes = await context.ISOCountryCodes.ToListAsync();
            return Ok(countryCodes);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<IEnumerable<ISOCountryCode>>> GetISOCountryCodesByCode(string code)
        {
            var countryCodes = await context.ISOCountryCodes
                .Where(cc => cc.CountryCode == code)
                .ToListAsync();

            return Ok(countryCodes);
        }
    }
}
