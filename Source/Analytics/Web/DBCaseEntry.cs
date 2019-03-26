using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class DbCaseEntry
    {
        public DbCaseEntry(int numberOfMalesAged5AndOlder, int numberOfFemalesUnder5, int numberOfFemalesAged5AndOlder, int numberOfMalesUnder5, string[] timestamp, Guid healthRisk, double longitude, double latitude)
        {
            NumberOfMalesAged5AndOlder = numberOfMalesAged5AndOlder;
            NumberOfFemalesUnder5 = numberOfFemalesUnder5;
            NumberOfFemalesAged5AndOlder = numberOfFemalesAged5AndOlder;
            NumberOfMalesUnder5 = numberOfMalesUnder5;
            Timestamp = timestamp;
            HealthRisk = healthRisk;
            Longitude = longitude;
            Latitude = latitude;
        }

        public DbCaseEntry()
        {}

        public int NumberOfMalesAged5AndOlder { get; set; }

        public int NumberOfFemalesUnder5 { get; set; }

        public int NumberOfFemalesAged5AndOlder { get; set; }

        public int NumberOfMalesUnder5 { get; set; }

        public string[] Timestamp { get; set; }

        public Guid HealthRisk { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
