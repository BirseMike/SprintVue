using MediatR;
using SprintVue.Models;
using SprintVue.Services;
using System.Threading;
using System.Threading.Tasks;

namespace SprintVue.Handlers
{

    public class GetSprintBurnUpCommand : IRequest<BurnUpData>
    {
        public string Id { get; set; }    
    }

    public class GetSprintBurnUpHandler : IRequestHandler<GetSprintBurnUpCommand, BurnUpData>
    {
        private readonly ISprintService _sprintService;

        public GetSprintBurnUpHandler(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        Task<BurnUpData> IRequestHandler<GetSprintBurnUpCommand, BurnUpData>.Handle(GetSprintBurnUpCommand command,
            CancellationToken cancellationToken)
        {
            var burnUpData = _sprintService.GetSprintBurnUp(command.Id);
            return Task.FromResult(burnUpData);
        }
    }
}
