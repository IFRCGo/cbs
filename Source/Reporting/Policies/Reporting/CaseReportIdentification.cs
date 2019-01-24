/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.Domain;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Domain.Reporting.CaseReports;
using Events.Management.DataCollectors.EditInformation;

namespace Policies.Reporting
{
    public class CaseReportIdentification : ICanProcessEvents
    {
        readonly IAggregateRootRepositoryFor<CaseReporting> _caseReportingAggregateRootRepository;
        readonly IReadModelRepositoryFor<Read.Reporting.CaseReports.CaseReportFromUnknownDataCollector> _unknownReports;
        readonly IReadModelRepositoryFor<Read.Reporting.InvalidCaseReports.InvalidCaseReportFromUnknownDataCollector> _invalidAndUnknownReports;
        readonly IReadModelRepositoryFor<Read.Reporting.DataCollectors.ListedDataCollector> _dataCollectors;

        public CaseReportIdentification(
            IAggregateRootRepositoryFor<CaseReporting> caseReportingAggregateRootRepository,
            IReadModelRepositoryFor<Read.Reporting.CaseReports.CaseReportFromUnknownDataCollector> unknownReports,
            IReadModelRepositoryFor<Read.Reporting.InvalidCaseReports.InvalidCaseReportFromUnknownDataCollector> invalidAndUnknownReports,
            IReadModelRepositoryFor<Read.Reporting.DataCollectors.ListedDataCollector> dataCollectors)
        {
            _caseReportingAggregateRootRepository = caseReportingAggregateRootRepository;
            _unknownReports = unknownReports;
            _invalidAndUnknownReports = invalidAndUnknownReports;
            _dataCollectors = dataCollectors;
        }
        
        [EventProcessor("477d2b8e-41cb-4746-9870-e7a8b2012997")]
        public void Process(PhoneNumberAddedToDataCollector @event, EventSourceId dataCollectorId)
        {
            var unknownReports = _unknownReports.Query.Where(r => r.Origin == @event.PhoneNumber);
            var dataCollector = _dataCollectors.GetById(dataCollectorId); 
            foreach (var item in unknownReports)
            {
                var caseReport = _caseReportingAggregateRootRepository.Get(item.Id.Value);
                caseReport.Report(
                    dataCollectorId,
                    item.HealthRiskId,
                    item.Origin,
                    item.NumberOfMalesUnder5,
                    item.NumberOfMalesAged5AndOlder,
                    item.NumberOfFemalesUnder5,
                    item.NumberOfFemalesAged5AndOlder,
                    dataCollector.Location.Longitude,
                    dataCollector.Location.Latitude,
                    item.Timestamp,
                    item.Message
                    
                    );
                caseReport.ReportFromUnknownDataCollectorIdentiefied(dataCollectorId);
            } 
                        
            var invalidAndUnknownReports = _invalidAndUnknownReports.Query.Where(r => r.PhoneNumber == @event.PhoneNumber);
            foreach (var item in invalidAndUnknownReports)
            {
                var caseReport = _caseReportingAggregateRootRepository.Get(item.Id.Value);
                caseReport.ReportInvalidReport(
                    dataCollectorId,
                    item.PhoneNumber,
                    item.Message,
                    dataCollector.Location.Longitude,
                    dataCollector.Location.Latitude,
                    item.ParsingErrorMessage,
                    item.Timestamp
                    
                    );
                caseReport.ReportFromUnknownDataCollectorIdentiefied(dataCollectorId);
            }
        }
    }
}