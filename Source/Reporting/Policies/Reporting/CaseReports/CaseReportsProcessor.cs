/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Domain;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Domain.Reporting.CaseReports;
using Dolittle.Runtime.Commands.Coordination;
using Events.Reporting.CaseReports;
using Dolittle.Runtime.Events;
using Read.Reporting.TrainingCaseReportsForListing;
using Concepts.CaseReports;
using Concepts.HealthRisks;
using System;
using System.Collections.Generic;

namespace Policies.Reporting.CaseReports
{
   public class CaseReportsProcessor : ICanProcessEvents
   {
       readonly IReadModelRepositoryFor<TrainingCaseReportForListing> _trainingReports;
       readonly ICommandContextManager _commandContextManager;
       readonly IAggregateRootRepositoryFor<CaseReporting> _caseReportingRepository;

       public CaseReportsProcessor(
           ICommandContextManager commandContextManager,
           IAggregateRootRepositoryFor<CaseReporting> caseReportingRepository)
       {
           _commandContextManager = commandContextManager;
           _caseReportingRepository = caseReportingRepository;
       }

        [EventProcessor("04623be4-2508-4f27-b845-8cc349ea8f17")]
       public void Process(TrainingReportConvertedToLive notification, EventSourceId caseReportId)
       {
            var transaction = _commandContextManager.EstablishForCommand(new Dolittle.Runtime.Commands.CommandRequest(Guid.NewGuid(), Guid.Empty, 0, new Dictionary<string, object>()));
            
            var report = _trainingReports.GetById((CaseReportId)caseReportId.Value);
            var aggregateRoot = _caseReportingRepository.Get(caseReportId);

            var reportFromKnownDataCollector = report.DataCollectorId != null && report.DataCollectorId != CaseReportId.NotSet;
            var validReport = report.HealthRiskId != null && report.HealthRiskId != HealthRiskId.NotSet;
            
            if (reportFromKnownDataCollector && validReport)
            {
                aggregateRoot.Report(
                    report.DataCollectorId.Value, report.HealthRiskId.Value, report.Origin, report.NumberOfMalesUnder5,
                    report.NumberOfMalesAged5AndOlder, report.NumberOfFemalesUnder5, report.NumberOfFemalesAged5AndOlder,
                    report.Location.Longitude, report.Location.Latitude, report.Timestamp, report.Message
                );
            }
            else if (reportFromKnownDataCollector && !validReport)
            {
                aggregateRoot.ReportInvalidReport(
                    report.DataCollectorId.Value, report.Origin, report.Message, report.Location.Longitude,
                    report.Location.Latitude, report.ParsingErrorMessage, report.Timestamp
                );
            }
            else if (!reportFromKnownDataCollector && validReport)
            {
                aggregateRoot.ReportFromUnknownDataCollector(
                    report.Origin, report.HealthRiskId.Value, report.NumberOfMalesUnder5, report.NumberOfMalesAged5AndOlder,
                    report.NumberOfFemalesUnder5, report.NumberOfFemalesAged5AndOlder, report.Timestamp, report.Message
                );
            }
            else if (!reportFromKnownDataCollector && !validReport)
            {
                aggregateRoot.ReportInvalidReportFromUnknownDataCollector(
                    report.Origin, report.Message, report.ParsingErrorMessage, report.Timestamp
                );
            }
            transaction.Commit();

       }
   }
}