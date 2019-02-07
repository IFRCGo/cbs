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
using Events.NotificationGateway.Reporting.SMS;
using Dolittle.Runtime.Commands.Coordination;

namespace Policies.Reporting.Notifications
{
   public class NotificationProcessor : ICanProcessEvents
   {
       readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;
       readonly IReadModelRepositoryFor<HealthRisk> _healthRisks;
       readonly INotificationParser _textMessageParser;
       readonly ICommandContextManager _commandContextManager;
       readonly IAggregateRootRepositoryFor<CaseReporting> _caseReportingRepository;

       public NotificationProcessor(
           ICommandContextManager commandContextManager,
           IReadModelRepositoryFor<DataCollector> dataCollectors,
           IReadModelRepositoryFor<HealthRisk> healthRisks,
           INotificationParser textMessageParser,
           IAggregateRootRepositoryFor<CaseReporting> caseReportingRepository)
       {
           _commandContextManager = commandContextManager;
           _dataCollectors = dataCollectors;
           _healthRisks = healthRisks;
           _textMessageParser = textMessageParser;
           _caseReportingRepository = caseReportingRepository;
       }

        [EventProcessor("acb536fe-38ae-46c9-b655-a8839d05abb7")]
       public void Process(TextMessageReceived notification)
       {
            var transaction = _commandContextManager.EstablishForCommand(new Dolittle.Runtime.Commands.CommandRequest(Guid.NewGuid(), Guid.NewGuid(), 1, new Dictionary<string, object>()));
           var parsingResult = _textMessageParser.Parse(notification);

           //        var filter = Builders<DataCollector>.Filter.AnyEq(c => c.PhoneNumbers, (PhoneNumber)phoneNumber);
           var isTextMessageFormatValid = parsingResult.IsValid;

           var dataCollector = _dataCollectors.Query.Where(_ => _.PhoneNumbers.Contains(new Concepts.DataCollectors.PhoneNumber(){Value = notification.Sender})).FirstOrDefault();

           var unknownDataCollector = dataCollector == null;

           var caseReportId = Guid.NewGuid();
           var caseReporting = _caseReportingRepository.Get(caseReportId);

           if (!isTextMessageFormatValid && unknownDataCollector)
           {
               caseReporting.ReportInvalidReportFromUnknownDataCollector(
                   notification.Sender,
                   notification.Text,
                   parsingResult.ErrorMessages,
                   notification.Received);

                    transaction.Commit();
               return;
           }

           if (!isTextMessageFormatValid && !unknownDataCollector)
           {
               caseReporting.ReportInvalidReport(
                    dataCollector.Id,
                    notification.Sender,
                    notification.Text,
                    dataCollector.Location.Longitude,
                    dataCollector.Location.Latitude,
                    parsingResult.ErrorMessages,
                    notification.Received);

                transaction.Commit();
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
                        notification.Sender,
                        notification.Text,
                        errorMessages,
                        notification.Received);
                    transaction.Commit();
                    return;
               }

               caseReporting.ReportInvalidReport(
                    dataCollector.Id,
                    notification.Sender,
                    notification.Text,
                    dataCollector.Location.Longitude,
                    dataCollector.Location.Latitude,
                    errorMessages,
                    notification.Received);
                transaction.Commit();
                return;
           }

           if (unknownDataCollector)
           {
                caseReporting.ReportFromUnknownDataCollector(
                    notification.Sender,
                    healthRiskId.Value,
                    parsingResult.MalesUnder5,
                    parsingResult.MalesAged5AndOlder,
                    parsingResult.FemalesUnder5,
                    parsingResult.FemalesAged5AndOlder,
                    notification.Received,
                    notification.Text
               );
                transaction.Commit();
                return;
           }

            caseReporting.Report(
                dataCollector.Id,
                healthRiskId.Value,
                notification.Sender,
                parsingResult.MalesUnder5,
                parsingResult.MalesAged5AndOlder,
                parsingResult.FemalesUnder5,
                parsingResult.FemalesAged5AndOlder,
                dataCollector.Location.Longitude,
                dataCollector.Location.Latitude,
                notification.Received,
                notification.Text
            );
            transaction.Commit();
       }
   }
}