using System;

namespace SprintVue.Models
{
    public class Sprint
    {
        public string Key   { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Ended { get; set; }
        public DateTime? ScheduledEnd { get; set; }
    }

}
