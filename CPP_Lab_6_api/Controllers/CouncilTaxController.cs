using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("mdm-council-tax")]
    public class CouncilTaxController : ControllerBase
    {
        private readonly DBContext context;

        public CouncilTaxController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CouncilTax>>> GetCouncilTaxes()
        {
            var items = await context.CouncilTaxes.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CouncilTax>>> GetCouncilTaxesById(long id)
        {
            var items = await context.CouncilTaxes
                .Where(it => it.CTResidentId == id)
                .ToListAsync();

            return Ok(items);
        }
    }
}