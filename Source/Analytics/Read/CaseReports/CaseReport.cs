using System;
using Dolittle.Collections;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class CaseReport : IReadModel
    {
        public int NumberOfMalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }        
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Guid HealthRisk { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; } 
    }

}
