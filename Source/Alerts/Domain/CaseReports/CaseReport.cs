using Alerts.Concepts;
using Alerts.Events;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using System;

namespace Domain.CaseReports
{
    public class CaseReport : AggregateRoot
    {
        private bool _isProcessed;

        public CaseReport(EventSourceId id) : base(id)
        { 
        }

        public void ProcessReport(CaseReportData caseReportData)
        {
            if (_isProcessed)
            {
                return;
            }

            GenerateCaseReceivedEvents(caseReportData, AgeGroup.AgeUnder5, Sex.Male, caseReportData.NumberOfMalesUnder5);
            GenerateCaseReceivedEvents(caseReportData, AgeGroup.Age5AndOver, Sex.Male, caseReportData.NumberOfMalesAged5AndOlder);
            GenerateCaseReceivedEvents(caseReportData, AgeGroup.AgeUnder5, Sex.Female, caseReportData.NumberOfFemalesUnder5);
            GenerateCaseReceivedEvents(caseReportData, AgeGroup.Age5AndOver, Sex.Female, caseReportData.NumberOfFemalesAged5AndOlder);
        }
        
        private void GenerateCaseReceivedEvents(CaseReportData caseReportData, AgeGroup group, Sex sex, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var caseRegistered = new CaseRegistered(
                    Guid.NewGuid(),
                    caseReportData.CaseReportId,
                    (int)group,
                    (int)sex,
                    caseReportData.Latitude,
                    caseReportData.Longitude,
                    caseReportData.Timestamp,
                    caseReportData.DataCollectorId,
                    caseReportData.HealthRiskId);

                Apply(caseRegistered);
            }
        }

        private void On(CaseRegistered @event)
        {
            _isProcessed = true;
        }
    }
}
