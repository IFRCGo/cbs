using System;
using Dolittle.ReadModels;

namespace Read.AgeAndSexDistribution
{
    public class AgeAndSexDistribution : IReadModel
    {
        public int NumberOfMalesUnder5 { get; set; }
        public int NumberOfMalesAged5AndOlder { get; set; }
        public int NumberOfFemalesUnder5 { get; set; }        
        public int NumberOfFemalesAged5AndOlder { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
}
