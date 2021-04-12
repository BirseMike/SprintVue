using SprintVue.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SprintVue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SprintItemController : ControllerBase
    {
        private readonly ILogger<SprintItemController> _logger;
        private IMediator _mediator;

        public SprintItemController(ILogger<SprintItemController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string sprintId)
        {
            var command = new GetSprintItemsCommand
            {
                Id = sprintId
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
