using Audi.BLL.DTO;
using Audi.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Audi.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AudiController : ControllerBase
    {
        private readonly IAudiService audiService;
        private readonly ILogger<AudiController> logger;

        public AudiController(IAudiService audiService, ILogger<AudiController> logger)
        {
            this.audiService = audiService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<AudiModelDTO>> GetAudiListAsync()
        {
            var result = await audiService.GetAsync();

            if (result == null)
            {
                logger.LogInformation($"Returned null array of Items on path {HttpContext.Request.Path}", DateTimeOffset.Now);
            }
            else
            {
                logger.LogInformation($"Returned {result.Count()} Item(s) on path {HttpContext.Request.Path}");
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<AudiModelDTO> GetAudiByIdAsync([FromRoute] int id)
        {
            var result = await audiService.GetAsync(id);

            if (result == null)
            {
                logger.LogInformation($"Model Not Found");
            }
            else
            {
                logger.LogInformation($"Get Model {HttpContext.Request.Path}");
            }

            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAudiAsync([FromRoute] int id, [FromBody] AudiModelDTO audiModelDTO)
        {
            await audiService.UpdateAsync(id, audiModelDTO);

            if (id == audiModelDTO.Id)
            {
                return NoContent();
            }
            
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<AudiModelDTO>> CreateAudiModel([FromBody] AudiModelDTO audiModelDTO)
        {
            var id = await audiService.CreateAsync(audiModelDTO);
            logger.LogInformation($"{nameof(CreateAudiModel)} action: Created New Model");

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAudiModel([FromRoute] int id)
        {
            await audiService.DeleteAsync(id);
            logger.LogInformation($"{nameof(DeleteAudiModel)} action: Delete Model.");
            return NoContent();
        }
    }
}