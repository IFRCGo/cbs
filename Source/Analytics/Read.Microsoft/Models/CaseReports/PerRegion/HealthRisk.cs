using System.Collections.Generic;

namespace Read.Models.CaseReports.PerRegion
{
    public class HealthRisk
    {
        public string Name { get; }

        public List<Region> Regions { get; set; }

        public HealthRisk(string name)
        {
            Name = name;
            Regions = new List<Region>();
        }
    }
}
