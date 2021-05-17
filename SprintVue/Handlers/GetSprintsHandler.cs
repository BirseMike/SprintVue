using SprintVue.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SprintVue.Models;

namespace SprintVue.Handlers
{

    public class GetSprintsCommand : IRequest<IEnumerable<Sprint>>
    {
    }

    public class GetSprintsHandler : IRequestHandler<GetSprintsCommand, IEnumerable<Sprint>>
    {
        private readonly ISprintService _sprintService;

        public GetSprintsHandler(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        Task<IEnumerable<Sprint>> IRequestHandler<GetSprintsCommand, IEnumerable<Sprint>>.Handle(GetSprintsCommand command,
            CancellationToken cancellationToken)
        {
            var sprints = _sprintService.GetSprints();
            return Task.FromResult(sprints);
        }
    }
}
