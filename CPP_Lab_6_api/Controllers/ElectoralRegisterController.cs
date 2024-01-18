using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("electoral-register")]
    public class ElectoralRegisterController : ControllerBase
    {
        private readonly DBContext context;

        public ElectoralRegisterController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectoralRegister>>> GetElectoralRegisters()
        {
            var items = await context.ElectoralRegisters.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ElectoralRegister>>> GetElectoralRegistersById(long id)
        {
            var items = await context.ElectoralRegisters
                .Where(it => it.ERVoterId == id)
                .ToListAsync();

            return Ok(items);
        }
    }
}