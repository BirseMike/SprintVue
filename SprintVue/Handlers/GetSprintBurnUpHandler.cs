using MediatR;
using SprintVue.Models;
using SprintVue.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SprintVue.Handlers
{

    public class GetSprintBurnUpCommand : IRequest<BurnUpChartData>
    {
        public string Id { get; set; }    
    }

    public class GetSprintBurnUpHandler : IRequestHandler<GetSprintBurnUpCommand, BurnUpChartData>
    {
        private readonly ISprintService _sprintService;

        public GetSprintBurnUpHandler(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        Task<BurnUpChartData> IRequestHandler<GetSprintBurnUpCommand, BurnUpChartData>.Handle(GetSprintBurnUpCommand command,
            CancellationToken cancellationToken)
        {
            var burnUpData = _sprintService.GetSprintBurnUp(command.Id);
            var sprintDays = burnUpData.SprintDays.ToList();
            var burnUpChartData = new BurnUpChartData
            {
                BurnPoints = burnUpData.BurnPoints.Select(x => new { x = sprintDays.IndexOf(x.ChangeDate), y = x.PointsChange, label = x.ChangeDate }).ToArray(),
                LoadPoints = burnUpData.LoadPoints.Select(x => new { x = sprintDays.IndexOf(x.ChangeDate), y = x.PointsChange, label = x.ChangeDate }).ToArray()
            };
            return Task.FromResult(burnUpChartData);
        }
    }

    public class BurnUpChartData
    {
        public dynamic[] LoadPoints { get; set; }
        public dynamic[] BurnPoints { get; set; }
    }
}
