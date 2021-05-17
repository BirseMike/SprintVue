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
            return Enumerable.Range(1, 100).Select(index => new
            SprintItem
            {
                Id = $"{rng.Next(5)}3000",
                Key = $"BLI-{index}000",
                Type = "Bug",
                Summary = $"Implement Story {index}",
                Status = "To-Do",
                Points = index,
                Labels = "Accessories,Others",
                Added = true,
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
