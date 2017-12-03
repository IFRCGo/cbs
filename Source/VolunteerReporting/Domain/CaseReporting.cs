using System;
using doLittle.Domain;
using doLittle.Runtime.Events;
using Concepts;
using Events;
using System.Collections.Generic;

namespace Domain
{
    public class CaseReporting : AggregateRoot
    {
        public CaseReporting(EventSourceId eventSourceId) : base(eventSourceId)
        {
        }

        public void ReportInvalidReport(
            DataCollectorId collector,
            string originalMessage,
            IEnumerable<string> errorMessages)
        {
            Apply(new InvalidReportReceived
            {
                CaseReportId = EventSourceId,
                DataCollectorId = collector,
                Message = originalMessage,
                ErrorMessages = errorMessages
            });
        }

        public void ReportInvalidReportFromUnknownDataCollector(
            string origin,
            string originalMessage,
            IEnumerable<string> errorMessages)
        {
            Apply(new InvalidReportFromUnknownDataCollectorReceived
            {
                CaseReportId = EventSourceId,
                Origin = origin,
                Message = originalMessage,
                ErrorMessages = errorMessages
            });

        }


        public void Report(
            Guid dataCollectorId,
            Guid healthRiskId,
            Sex sex,
            int age,
            double longitude,
            double latitude)
        {
            Apply(new CaseReportReceived
            {
                CaseReportId = EventSourceId,
                DataCollectorId = dataCollectorId,
                HealthRiskId = healthRiskId,
                Sex = (int)sex,
                Age = age,
                Longitude = longitude,
                Latitude = latitude
            });
        }

        public void ReportMultiple(
            Guid dataCollectorId,
            Guid healthRiskId,
            int numberOfMalesUnder5,
            int numberOfMalesOver5,
            int numberOfFemalesUnder5,
            int numberOfFemalesOver5,
            double longitude,
            double latitude)
        {
            Apply(new MultipleCaseReportsReceived
            {
                CaseReportId = EventSourceId,
                HealthRiskId = healthRiskId,
                NumberOfMalesUnder5 = numberOfMalesUnder5,
                NumberOfMalesOver5 = numberOfMalesOver5,
                NumberOfFemalesUnder5 = numberOfFemalesUnder5,
                NumberOfFemalesOver5 = numberOfFemalesOver5,
                Longitude = longitude,
                Latitude = latitude
            });
        }

        public void ReportFromUnknownDataCollector(
            string origin,
            Guid healthRiskId,
            Sex sex,
            int age,
            double longitude,
            double latitude)
        {
            Apply(new CaseReportFromUnknownDataCollectorReceived
            {
                CaseReportId = EventSourceId,
                Origin = origin,
                HealthRiskId = healthRiskId,
                Sex = (int)sex,
                Age = age,
                Longitude = longitude,
                Latitude = latitude
            });

        }

        public void ReportMultipleFromUnknownDataCollector(
            string origin,
            Guid healthRiskId,
            int numberOfMalesUnder5,
            int numberOfMalesOver5,
            int numberOfFemalesUnder5,
            int numberOfFemalesOver5,
            double longitude,
            double latitude)
        {
            Apply(new MultipleCaseReportsFromUnknownDataCollectorReceived
            {
                Origin = origin,
                CaseReportId = EventSourceId,
                HealthRiskId = healthRiskId,
                NumberOfFemalesUnder5 = numberOfFemalesUnder5,
                NumberOfFemalesOver5 = numberOfFemalesOver5,
                NumberOfMalesUnder5 = numberOfMalesUnder5,
                NumberOfMalesOver5 = numberOfMalesOver5,
                Longitude = longitude,
                Latitude = latitude
            });
        }
    }
}