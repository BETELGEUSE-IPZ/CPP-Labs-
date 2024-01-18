using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("mdm-services")]
    public class MDMServicesController : ControllerBase
    {
        private readonly DBContext context;

        public MDMServicesController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MDMServices>>> GetMDMServices()
        {
            var items = await context.MDMServices.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MDMServices>>> GetMDMServicesById(long id)
        {
            var items = await context.MDMServices
                .Where(it => it.ServiceId == id)
                .ToListAsync();

            return Ok(items);
        }
    }
}
