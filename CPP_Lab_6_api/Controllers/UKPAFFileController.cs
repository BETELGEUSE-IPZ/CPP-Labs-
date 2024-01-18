using lab6_api.Data.DB;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("uk-paf-files")]
    public class UKPAFFileController : ControllerBase
    {
        private readonly DBContext context;

        public UKPAFFileController(DBContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UKPAFFile>>> GetUKPAFFiles()
        {
            var ukpafFiles = await context.UKPAFFiles.ToListAsync();
            return Ok(ukpafFiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UKPAFFile>>> GetUKPAFFileById(long id)
        {
            var ukpafFiles = await context.UKPAFFiles
                .Where(uk => uk.PafAddressId == id)
                .ToListAsync();

            return Ok(ukpafFiles);
        }
    }
}
