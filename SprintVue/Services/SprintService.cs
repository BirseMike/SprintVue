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

            return Enumerable.Range(1, 100).Select(index => new
            SprintItem
            {
                Id = $"{rng.Next(5)}3000",
                Key = $"BLI-{index}000",
                Type = "Bug",
                Summary = $"Implement Story {index}",
                Status = statuses[rng.Next(1,4)],
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
            return new SprintReport
            {
                Items = GetSprintItems(sprintId).ToDictionary(x => x.Key, x => x.Points.ToString())
            };
        }

        public BurnUpData GetSprintBurnUp(string sprintId)
        {
            return new BurnUpData
            {
                LoadPoints = new List<DataPoint> { new DataPoint { ChangeDate = DateTime.Now.AddDays(-5), PointsChange = 5 } },
                BurnPoints = new List<DataPoint> { 
                    new DataPoint { ChangeDate = DateTime.Now.AddDays(-3), PointsChange = 3 },
                    new DataPoint { ChangeDate = DateTime.Now, PointsChange = 2 },
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
                Ended = DateTime.Today.AddDays((-15 * index)+14)
            })
            .ToArray();
        }

    }
}
