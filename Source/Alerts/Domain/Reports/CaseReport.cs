using System;
using Concepts;
using Concepts.CaseReports;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Reports;

namespace Domain.Reports
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

            int healthRiskNumber = this.GetHealthRiskNumber(caseReportData.Message);

            GenerateReportRegisteredEvents(caseReportData, AgeGroup.AgeUnder5, Sex.Male, caseReportData.NumberOfMalesUnder5, healthRiskNumber);
            GenerateReportRegisteredEvents(caseReportData, AgeGroup.Age5AndOver, Sex.Male, caseReportData.NumberOfMalesAged5AndOlder, healthRiskNumber);
            GenerateReportRegisteredEvents(caseReportData, AgeGroup.AgeUnder5, Sex.Female, caseReportData.NumberOfFemalesUnder5, healthRiskNumber);
            GenerateReportRegisteredEvents(caseReportData, AgeGroup.Age5AndOver, Sex.Female, caseReportData.NumberOfFemalesAged5AndOlder, healthRiskNumber);
        }

        private int GetHealthRiskNumber(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new InvalidOperationException($"{nameof(message)} should not be empty or whitespace");
            }

            var parts = message.Split('#', '*');
            var healthNumberPart = parts[0];
            int healthRiskNumber;
            if(!int.TryParse(healthNumberPart, out healthRiskNumber))
            {
                throw new InvalidOperationException($"Can't parse health risk number from \"{healthNumberPart}!");
            }

            return healthRiskNumber;
        }

        private void GenerateReportRegisteredEvents(
            CaseReportData caseReportData, 
            AgeGroup group, 
            Sex sex, 
            int count,
            int healthRiskNumber)
        {
            for (int i = 0; i < count; i++)
            {
                var reportRegistered = new ReportRegistered(
                    Guid.NewGuid(),
                    caseReportData.CaseReportId,
                    (int)group,
                    (int)sex,
                    caseReportData.Latitude,
                    caseReportData.Longitude,
                    caseReportData.Timestamp,
                    caseReportData.DataCollectorId,
                    caseReportData.HealthRiskId,
                    healthRiskNumber,
                    caseReportData.PhoneNumber);

                Apply(reportRegistered);
            }
        }

        private void On(ReportRegistered @event)
        {
            _isProcessed = true;
        }
    }
}
