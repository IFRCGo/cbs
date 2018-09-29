/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts;
using Domain;
using Read.DataCollectors;
using Read.HealthRisks;
using Dolittle.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Concepts.HealthRisk;
using Domain.CaseReports;
using Events.External;

namespace Policy.Notifications
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanProcessTextMessage"/>
    /// </summary>
    public class NotificationProcessor : ICanProcessNotification
    {
        readonly IDataCollectors _dataCollectors;
        readonly IHealthRisks _healthRisks;
        readonly INotificationParser _textMessageParser;
        private readonly IAggregateRootRepositoryFor<CaseReporting> _caseReportingRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="TextMessageProcessor"/>
        /// </summary>
        /// <param name="dataCollectors"><see cref="IDataCollectors"/></param>
        /// <param name="healthRisks"><see cref="IHealthRisks"/></param>
        /// <param name="textMessageParser"><see cref="ITextMessageContentParser"/></param>
        /// <param name="caseReportingRepository"><see cref="IAggregateRootRepository<CaseReporting>"/></param>
        public NotificationProcessor(
            IDataCollectors dataCollectors,
            IHealthRisks healthRisks,
            INotificationParser textMessageParser,
            IAggregateRootRepositoryFor<CaseReporting> caseReportingRepository)
        {
            _dataCollectors = dataCollectors;
            _healthRisks = healthRisks;
            _textMessageParser = textMessageParser;
            _caseReportingRepository = caseReportingRepository;
        }

        /// <inheritdoc/>
        public void Process(NotificationReceived notification)
        {
            var parsingResult = _textMessageParser.Parse(notification);

            var isTextMessageFormatValid = parsingResult.IsValid;
            var dataCollector = _dataCollectors.GetByPhoneNumber(notification.OriginNumber);
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
            var healthRiskId = _healthRisks.GetIdFromReadableId(healthRiskReadableId);
            if (healthRiskId == HealthRiskId.NotSet)
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