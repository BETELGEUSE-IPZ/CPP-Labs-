using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("housing-benefits")]
    public class HousingBenefitsController : ControllerBase
    {
        private readonly DBContext context;

        public HousingBenefitsController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HousingBenefits>>> GetHousingBenefits()
        {
            var items = await context.HousingBenefits.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<HousingBenefits>>> GetHousingBenefitsById(long id)
        {
            var items = await context.HousingBenefits
                .Where(it => it.HBRecipientId == id)
                .ToListAsync();

            return Ok(items);
        }
    }
}