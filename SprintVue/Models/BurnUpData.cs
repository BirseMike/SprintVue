using System.Collections.Generic;

namespace SprintVue.Models
{
    public class BurnUpData
    {
        public IList<DataPoint> LoadPoints { get; set; }
        public IList<DataPoint> BurnPoints { get; set; }
    }
}