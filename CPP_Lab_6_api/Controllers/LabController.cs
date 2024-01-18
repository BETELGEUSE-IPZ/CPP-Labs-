using lab6_api.Data;
using lab6_api.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace lab6_api.Controllers
{
    [ApiController]
    [Route("lab")]
    public class LabController: ControllerBase
    {
        private readonly LabExecutorDataSource labExecutorDataSource;

        public LabController(LabExecutorDataSource labExecutorDataSource)
        {
            this.labExecutorDataSource = labExecutorDataSource;
        }

        [HttpPost("lab1")]
        public async Task<ActionResult<string>> ExecuteLab1([FromBody] LabRequest labRequest)
        {
            string output = labExecutorDataSource.ExecuteLab1(labRequest.Input);
            return Ok(output);
        }

        [HttpPost("lab2")]
        public async Task<ActionResult<string>> ExecuteLab2([FromBody] LabRequest labRequest)
        {
            string output = labExecutorDataSource.ExecuteLab2(labRequest.Input);
            return Ok(output);
        }

        [HttpPost("lab3")]
        public async Task<ActionResult<string>> ExecuteLab3([FromBody] LabRequest labRequest)
        {
            string output = labExecutorDataSource.ExecuteLab3(labRequest.Input);
            return Ok(output);
        }
    }
}
