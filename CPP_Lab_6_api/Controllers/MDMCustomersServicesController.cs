using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("mdm-customer-services")]
    public class MDMCustomersServicesController : ControllerBase
    {
        private readonly DBContext context;

        public MDMCustomersServicesController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MDMCustomersServices>>> GetMDMCustomerServices()
        {
            var items = await context.MDMCustomersServices.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MDMCustomersServices>>> GetMDMCustomerServicesById(long id)
        {
            var items = await context.MDMCustomersServices
                .Where(it => it.MDMCustomerId == id)
                .ToListAsync();

            return Ok(items);
        }
    }
}