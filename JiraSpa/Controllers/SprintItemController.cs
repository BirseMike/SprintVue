using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiraSpa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SprintItemController : ControllerBase
    {
        private readonly ILogger<SprintItemController> _logger;

        public SprintItemController(ILogger<SprintItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new {
                id= "1000",
                key= $"BLI-000{index}",
                type= "Bug",
                summary=$"Implement Story {index}",
                status= "To-Do",
                points= 3,
                labels= "Accessories,Others",
                added= true
            })
            .ToArray();
        }
    }
}
