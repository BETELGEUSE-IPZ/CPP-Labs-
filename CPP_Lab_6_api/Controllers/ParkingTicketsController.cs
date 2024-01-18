using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("parking-tickets")]
    public class ParkingTicketsController : ControllerBase
    {
        private readonly DBContext context;

        public ParkingTicketsController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingTickets>>> GetParkingTickets()
        {
            var items = await context.ParkingTickets.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ParkingTickets>>> GetParkingTicketsById(long id)
        {
            var items = await context.ParkingTickets
                .Where(it => it.PTOffenderId == id)
                .ToListAsync();

            return Ok(items);
        }
    }
}