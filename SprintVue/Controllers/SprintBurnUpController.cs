using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SprintVue.Handlers;
using System.Threading.Tasks;

namespace SprintVue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SprintBurnUpController : ControllerBase
    {
        private readonly ILogger<SprintBurnUpController> _logger;
        private IMediator _mediator;

        public SprintBurnUpController(ILogger<SprintBurnUpController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string sprintId)
        {
            var command = new GetSprintBurnUpCommand
            {
                Id = sprintId
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
