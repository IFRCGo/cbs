using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using Read.CaseReports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Read.HealthRisks
{
    public class HealthRisk : BaseReadModel
    {
        public Guid HealthRiskId { get; set; }
        public string Name { get; set; }

        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<DateTimeOffset, int> ReportsPerDay { get; set; }

        public HealthRisk(Guid id, string name)
        {
            HealthRiskId = id;
            Name = name;
            ReportsPerDay = new Dictionary<DateTimeOffset, int>();
        }

        public void ReportReceived(CaseReport caseReport)
        {
            var totalReportedCases = caseReport.NumberOfFemalesAged5AndOlder + caseReport.NumberOfFemalesUnder5 + 
                caseReport.NumberOfMalesAged5AndOlder + caseReport.NumberOfMalesUnder5;
            if (ReportsPerDay.Keys.Contains(caseReport.Timestamp))
                ReportsPerDay[caseReport.Timestamp] = ReportsPerDay[caseReport.Timestamp] + totalReportedCases;
            else
                ReportsPerDay[caseReport.Timestamp] = totalReportedCases;
        }
    }
}
