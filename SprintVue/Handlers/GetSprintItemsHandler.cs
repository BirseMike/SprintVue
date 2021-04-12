using SprintVue.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SprintVue.Handlers
{

    public class GetSprintItemsCommand : IRequest<SprintItem[]>
    {
        public string Id { get; set; }    
    }

    public class GetSprintItemsHandler : IRequestHandler<GetSprintItemsCommand, SprintItem[]>
    {
        private readonly ISprintService _sprintService;

        public GetSprintItemsHandler(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        Task<SprintItem[]> IRequestHandler<GetSprintItemsCommand, SprintItem[]>.Handle(GetSprintItemsCommand command,
            CancellationToken cancellationToken)
        {
            var items = _sprintService.GetSprintItems(command.Id);
            return Task.FromResult(items);
        }
    }
}
