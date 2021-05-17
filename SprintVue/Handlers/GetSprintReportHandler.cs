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

    public class GetSprintReportCommand : IRequest<SprintReport>
    {
        public string Id { get; set; }    
    }

    public class GetSprintReportHandler : IRequestHandler<GetSprintReportCommand, SprintReport>
    {
        private readonly ISprintService _sprintService;

        public GetSprintReportHandler(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        Task<SprintReport> IRequestHandler<GetSprintReportCommand, SprintReport>.Handle(GetSprintReportCommand command,
            CancellationToken cancellationToken)
        {
            var report = _sprintService.GetSprintReport(command.Id);
            return Task.FromResult(report);
        }
    }
}
