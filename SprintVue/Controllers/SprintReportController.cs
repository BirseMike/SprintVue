using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SprintVue.Handlers;
using System.Threading.Tasks;

namespace SprintVue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SprintReportController : ControllerBase
    {
        private readonly ILogger<SprintReportController> _logger;
        private IMediator _mediator;

        public SprintReportController(ILogger<SprintReportController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string sprintId)
        {
            var command = new GetSprintReportCommand
            {
                Id = sprintId
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
