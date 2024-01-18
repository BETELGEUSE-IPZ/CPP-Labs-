using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("social-services")]
    public class SocialServicesController : ControllerBase
    {
        private readonly DBContext context;

        public SocialServicesController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocialServices>>> GetSocialServices()
        {
            var items = await context.SocialServices.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SocialServices>>> GetSocialServicesById(long id)
        {
            var items = await context.SocialServices
                .Where(it => it.SSClientId == id)
                .ToListAsync();

            return Ok(items);
        }
    }
}