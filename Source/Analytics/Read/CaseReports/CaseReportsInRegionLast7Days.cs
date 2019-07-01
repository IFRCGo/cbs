using Concepts;
using Dolittle.ReadModels;
using System;

namespace Read.CaseReports
{
    public class CaseReportsInRegionLast7Days : IReadModel
    {
        public Day Id { get; set; }
        public Region Region { get; set; }
        public NumberOfPeople NumberOfCaseReports { get; set; }
    }
}