using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JiraSpa.Services
{
    public class SprintService : ISprintService
    {
        public SprintItem[] GetSprintItems(string sprint)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new
            SprintItem {
                Id = $"{index}3000",
                Key = $"BLI-{index}000",
                Type = "Bug",
                Summary = $"Implement Story {index}",
                Status = "To-Do",
                Points = index ,
                Labels = "Accessories,Others",
                Added = true
            })
            .ToArray();
        }
    }

    public class SprintItem
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public int Points { get; set; }
        public string Labels { get; set; }
        public bool Added { get; set; }

    }
}
