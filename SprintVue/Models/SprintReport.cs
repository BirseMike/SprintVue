using System.Collections.Generic;

namespace SprintVue.Models
{
    public class SprintReport
    {
        public IDictionary<string, string> Items { get; set; }
        public int NoStoriesAdded { get; internal set; }
        public int NoStoriesRemoved { get; internal set; }
        public int NoStoriesCommitted { get; internal set; }
        public int NoStoriesCompleted { get; internal set; }
        public int NoStoriesInAcceptance { get; internal set; }
        public int NoStoriesInSprint { get; internal set; }
        public int PointsCompleted { get; internal set; }
        public int PointsAdded { get; internal set; }
        public int PointsCommitted { get; internal set; }
    }

}
