using MediatR;
using SprintVue.Models;
using SprintVue.Services;
using System.Linq;
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
            burnUpData.BurnPoints = burnUpData.BurnPoints.GroupBy(x => x.ChangeDate).Select(x => new DataPoint { ChangeDate = x.Key, PointsChange = x.Sum(p => p.PointsChange) }).ToList();
            burnUpData.LoadPoints = burnUpData.LoadPoints.GroupBy(x => x.ChangeDate).Select(x => new DataPoint { ChangeDate = x.Key, PointsChange = x.Sum(p => p.PointsChange) }).ToList();
            return Task.FromResult(burnUpData);
        }
    }
}
