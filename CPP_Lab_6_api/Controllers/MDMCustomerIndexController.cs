using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("mdm-customer-index")]
    public class MDMCustomerIndexController : ControllerBase
    {
        private readonly DBContext context;

        public MDMCustomerIndexController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MDMCustomerIndex>>> GetMDMCustomerIndices()
        {
            var items = await context.MDMCustomerIndices.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MDMCustomerIndex>>> GetMDMCustomerIndicesById(long id)
        {
            var items = await context.MDMCustomerIndices
                .Where(it => it.MDMCustomerId == id)
                .ToListAsync();

            return Ok(items);
        }
    }
}
