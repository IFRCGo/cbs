using System;
using Dolittle.ReadModels;

namespace Read.CaseReports
{
    public class AlertsByWeek : IReadModel
    {
        public short Year { get; set; }
        
        public short Week { get; set; }

        public int AlertCount { get; set; }
    }
}
