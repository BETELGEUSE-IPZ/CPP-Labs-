using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("mdm-payments")]
    public class MDMPaymentsController : ControllerBase
    {
        private readonly DBContext context;

        public MDMPaymentsController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MDMPayments>>> GetMDMPayments()
        {
            var items = await context.MDMPayments.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MDMPayments>>> GetMDMPaymentsById(long id)
        {
            var items = await context.MDMPayments
                .Where(it => it.MDMPaymentId == id)
                .ToListAsync();

            return Ok(items);
        }
    }
}