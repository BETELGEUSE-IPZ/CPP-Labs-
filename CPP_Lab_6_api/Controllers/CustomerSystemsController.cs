using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("customer-systems")]
    public class CustomerSystemsController : ControllerBase
    {
        private readonly DBContext context;

        public CustomerSystemsController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerSystems>>> GetCustomerSystems()
        {
            var items = await context.CustomerSystems.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<IEnumerable<CustomerSystems>>> GetCustomerSystemsByCode(long code)
        {
            var items = await context.CustomerSystems
                .Where(it => it.SystemCode == code)
                .ToListAsync();

            return Ok(items);
        }
    }
}
