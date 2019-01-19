/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Read.Management.DataCollectors;
using Read.Reporting.HealthRisks;
using Dolittle.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Concepts.HealthRisks;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Domain.Reporting.CaseReports;
using Events.Admin.Reporting.HealthRisks;

namespace Policies.Reporting.Notifications
{
   public class NotificationProcessor : ICanProcessEvents
   {
       readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;
       readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;
       readonly INotificationParser _textMessageParser;
       private readonly IAggregateRootRepositoryFor<CaseReporting> _caseReportingRepository;

       public NotificationProcessor(
           IReadModelRepositoryFor<DataCollector> dataCollectors,
           IReadModelRepositoryFor<HealthRisk> healthRisks,
           INotificationParser textMessageParser,
           IAggregateRootRepositoryFor<CaseReporting> caseReportingRepository)
       {
           _dataCollectors = dataCollectors;
           _healthRisks = healthRisks;
           _textMessageParser = textMessageParser;
           _caseReportingRepository = caseReportingRepository;
       }

       public void Process(NotificationReceived notification)
       {
           var parsingResult = _textMessageParser.Parse(notification);

           //        var filter = Builders<DataCollector>.Filter.AnyEq(c => c.PhoneNumbers, (PhoneNumber)phoneNumber);
           var isTextMessageFormatValid = parsingResult.IsValid;

           var dataCollector = _dataCollectors.Query.Where(_ => _.PhoneNumbers.Contains(new Concepts.DataCollectors.PhoneNumber(notification.OriginNumber))).FirstOrDefault();

           var unknownDataCollector = dataCollector == null;

           var caseReportId = Guid.NewGuid();
           var caseReporting = _caseReportingRepository.Get(caseReportId);

           if (!isTextMessageFormatValid && unknownDataCollector)
           {
               caseReporting.ReportInvalidReportFromUnknownDataCollector(
                   notification.OriginNumber,
                   notification.Message,
                   parsingResult.ErrorMessages,
                   notification.Sent);
               return;
           }

           if (!isTextMessageFormatValid && !unknownDataCollector)
           {
               caseReporting.ReportInvalidReport(
                   dataCollector.Id,
                   notification.OriginNumber,
                   notification.Message,
                   dataCollector.Location.Longitude,
                   dataCollector.Location.Latitude,
                   parsingResult.ErrorMessages,
                   notification.Sent);
               return;
           }

           var healthRiskReadableId = parsingResult.HealthRiskReadableId;
           var healthRiskId = _healthRisks.Query.Where(i => i.ReadableId == healthRiskReadableId).FirstOrDefault()?.Id;
           if (healthRiskId == null || healthRiskId == HealthRiskId.NotSet)
           {
               var errorMessages = new List<string> { $"Unable to find health risk, since there are no health risks with a readable id of {healthRiskReadableId}" };
               if (unknownDataCollector)
               {
                   caseReporting.ReportInvalidReportFromUnknownDataCollector(
                       notification.OriginNumber,
                       notification.Message,
                       errorMessages,
                       notification.Sent);
                   return;
               }

               caseReporting.ReportInvalidReport(
                   dataCollector.Id,
                   notification.OriginNumber,
                   notification.Message,
                   dataCollector.Location.Longitude,
                   dataCollector.Location.Latitude,
                   errorMessages,
                   notification.Sent);
               return;
           }

           if (unknownDataCollector)
           {
               caseReporting.ReportFromUnknownDataCollector(
                   notification.OriginNumber,
                   healthRiskId.Value,
                   parsingResult.MalesUnder5,
                   parsingResult.MalesAged5AndOlder,
                   parsingResult.FemalesUnder5,
                   parsingResult.FemalesAged5AndOlder,
                   notification.Sent,
                   notification.Message
               );
               return;
           }

           caseReporting.Report(
               dataCollector.Id,
               healthRiskId.Value,
               notification.OriginNumber,
               parsingResult.MalesUnder5,
               parsingResult.MalesAged5AndOlder,
               parsingResult.FemalesUnder5,
               parsingResult.FemalesAged5AndOlder,
               dataCollector.Location.Longitude,
               dataCollector.Location.Latitude,
               notification.Sent,
               notification.Message
           );
       }
   }
}