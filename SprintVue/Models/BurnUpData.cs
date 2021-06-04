using System;
using System.Collections.Generic;

namespace SprintVue.Models
{
    public class BurnUpData
    {
        public DateTime[] SprintDays { get; set; }
        public IList<DataPoint> LoadPoints { get; set; }
        public IList<DataPoint> BurnPoints { get; set; }
    }
}