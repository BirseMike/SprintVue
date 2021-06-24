using SprintVue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SprintVue.Services
{
    public class SprintService : ISprintService
    {
        public IList<SprintItem> GetAllBackLogItems()
        {
            var rng = new Random();

            var statuses = new Dictionary<int, string>
            {
                { 1,"To-Do" },
                { 2,"In Progress" },
                { 3,"In Acceptance" },
                { 4,"Done" },
            };

            return Enumerable.Range(1, 50).Select(index => new
            SprintItem
            {
                Id = $"{rng.Next(5)}3000",
                Key = $"BLI-{index}000",
                Type = "Bug",
                Summary = $"Implement Story {index}",
                Status = statuses[rng.Next(1,5)],
                Points = index,
                Labels = "Accessories,Others",
                Added = index % 2 == 0,
                SprintKey = $"Sprint-{rng.Next(1,5)}"
            })
            .ToArray();
        }

        public IList<SprintItem> GetFullBackLog()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SprintItem> GetSprintItems(string sprintId)
        {
            return GetAllBackLogItems().Where(i => i.SprintKey == sprintId);
        }

        public SprintReport GetSprintReport(string sprintId)
        {
            var rng = new Random();
            var items = GetSprintItems(sprintId).ToList();
            return new SprintReport
            {
                NoStoriesAdded = items.Count(x => x.Added),
                NoStoriesRemoved = rng.Next(1, items.Count(x => x.Status != "Done")),
                NoStoriesInSprint = items.Count(),
                NoStoriesCommitted = items.Count(x => !x.Added),
                NoStoriesInAcceptance = items.Count(x => x.Status == "In Acceptance"),
                NoStoriesCompleted = items.Count(x => x.Status == "Done"),
                PointsCommitted = items.Where(x => !x.Added).Sum(s => s.Points),
                PointsAdded = items.Where(x => x.Added).Sum(s => s.Points),
                PointsCompleted = items.Where(x => x.Status == "Done").Sum(p => p.Points),
                Items = items.ToDictionary(x => x.Key, x => x.Points.ToString())
            };
        }

        public BurnUpData GetSprintBurnUp(string sprintId)
        {
            var sprint = GetSprints().FirstOrDefault(s => s.Key == sprintId);
            if (sprint == null)
                return new BurnUpData()
                {
                    SprintDays = new DateTime[0],
                    BurnPoints = new List<DataPoint>(),
                    LoadPoints = new List<DataPoint>()
                };


            var sprintLength = ((TimeSpan)(sprint.ScheduledEnd - sprint.Start)).Days;

            //todo make the data a set of matching arrays..

            return new BurnUpData
            {
                SprintDays = Enumerable.Range(0, sprintLength).Select(day => sprint.Start.AddDays(day)).ToArray(),
                LoadPoints = new List<DataPoint> { 
                    new DataPoint { ChangeDate = sprint.Start.AddDays(0), PointsChange = 20 },
                    new DataPoint { ChangeDate = sprint.Start.AddDays(2), PointsChange = 17 },
                    new DataPoint { ChangeDate = sprint.Start.AddDays(sprintLength-1), PointsChange = 17 },
                },
                BurnPoints = new List<DataPoint> {
                    new DataPoint { ChangeDate = sprint.Start.AddDays(0), PointsChange = 0 },
                    new DataPoint { ChangeDate = sprint.Start.AddDays(3), PointsChange = 3 },
                    new DataPoint { ChangeDate = sprint.Start.AddDays(8), PointsChange = 8 },
                    new DataPoint { ChangeDate = sprint.Start.AddDays(10), PointsChange = 11 },
                    new DataPoint { ChangeDate = sprint.Start.AddDays(sprintLength-1), PointsChange = 11 },
                }
            };
        }


        public IEnumerable<Sprint> GetSprints()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new
            Sprint
            {
                Key = $"Sprint-{index}",
                Start = DateTime.Today.AddDays(-15*index),
                ScheduledEnd = DateTime.Today.AddDays((-15 * index)+14),
                Ended = DateTime.Today.AddDays((-15 * index) + 14)
            })
            .ToArray();
        }

    }
}
