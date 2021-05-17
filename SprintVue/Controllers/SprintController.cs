using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SprintVue.Handlers;
using System.Threading.Tasks;

namespace SprintVue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SprintController : ControllerBase
    {
        private readonly ILogger<SprintController> _logger;
        private IMediator _mediator;

        public SprintController(ILogger<SprintController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var command = new GetSprintsCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
