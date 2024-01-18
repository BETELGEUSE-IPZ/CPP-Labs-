using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("parking-payments")]
    public class ParkingPaymentsController : ControllerBase
    {
        private readonly DBContext context;

        public ParkingPaymentsController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingPayments>>> GetParkingPayments()
        {
            var items = await context.ParkingPayments.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ParkingPayments>>> GetParkingPaymentsById(long id)
        {
            var items = await context.ParkingPayments
                .Where(it => it.PaymentId == id)
                .ToListAsync();

            return Ok(items);
        }
    }
}