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

    public class GetSprintItemsCommand : IRequest<IEnumerable<SprintItem>>
    {
        public string Id { get; set; }    
    }

    public class GetSprintItemsHandler : IRequestHandler<GetSprintItemsCommand, IEnumerable<SprintItem>>
    {
        private readonly ISprintService _sprintService;

        public GetSprintItemsHandler(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        Task<IEnumerable<SprintItem>> IRequestHandler<GetSprintItemsCommand, IEnumerable<SprintItem>>.Handle(GetSprintItemsCommand command,
            CancellationToken cancellationToken)
        {
            var items = _sprintService.GetSprintItems(command.Id);
            return Task.FromResult(items);
        }
    }
}
