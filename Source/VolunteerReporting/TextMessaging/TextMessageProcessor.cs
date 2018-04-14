/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Infrastructure.TextMessaging;
using Concepts;
using Domain;
using Read.DataCollectors;
using Read.HealthRisks;
using doLittle.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TextMessaging
{
    /// <summary>
    /// Represents an implementation of <see cref="ICanProcessTextMessage"/>
    /// </summary>
    public class TextMessageProcessor : ICanProcessTextMessage
    {
        readonly IDataCollectors _dataCollectors;
        readonly IHealthRisks _healthRisks;
        readonly ITextMessageParser _textMessageParser;
        private readonly IAggregateRootRepositoryFor<CaseReporting> _caseReportingRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="TextMessageProcessor"/>
        /// </summary>
        /// <param name="dataCollectors"><see cref="IDataCollectors"/></param>
        /// <param name="healthRisks"><see cref="IHealthRisks"/></param>
        /// <param name="textMessageParser"><see cref="ITextMessageContentParser"/></param>
        /// <param name="caseReportingRepository"><see cref="IAggregateRootRepository<CaseReporting>"/></param>
        public TextMessageProcessor(
            IDataCollectors dataCollectors,
            IHealthRisks healthRisks,
            ITextMessageParser textMessageParser,
            IAggregateRootRepositoryFor<CaseReporting> caseReportingRepository)
        {
            _dataCollectors = dataCollectors;
            _healthRisks = healthRisks;
            _textMessageParser = textMessageParser;
            _caseReportingRepository = caseReportingRepository;
        }

        /// <inheritdoc/>
        public void Process(TextMessage message)
        {
            var parsingResult = _textMessageParser.Parse(message);
            var isTextMessageFormatValid = parsingResult.IsValid;
            var dataCollector = _dataCollectors.GetByPhoneNumber(message.OriginNumber);
            var unknownDataCollector = dataCollector == null;
            var caseReportId = Guid.NewGuid();
            var caseReporting = _caseReportingRepository.Get(caseReportId);
            if (!isTextMessageFormatValid && unknownDataCollector)
            {
                caseReporting.ReportInvalidReportFromUnknownDataCollector(
                    message.OriginNumber,
                    message.Message,
                    parsingResult.ErrorMessages,
                    message.Sent);                
                return;                
            }

            if (!isTextMessageFormatValid && !unknownDataCollector)
            {
                caseReporting.ReportInvalidReport(
                    dataCollector.Id,
                    message.OriginNumber,
                    message.Message,
                    parsingResult.ErrorMessages,
                    message.Sent);                
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
                        message.OriginNumber,
                        message.Message,
                        errorMessages,
                        message.Sent);                    
                    return;
                }
                else
                {
                    caseReporting.ReportInvalidReport(
                        dataCollector.Id,
                        message.OriginNumber,
                        message.Message,
                        errorMessages,
                        message.Sent);
                    return;
                }               
            }            

            if (unknownDataCollector)
            {
                caseReporting.ReportFromUnknownDataCollector(
                    message.OriginNumber,
                    healthRiskId,
                    parsingResult.MalesUnder5,
                    parsingResult.MalesAged5AndOlder,
                    parsingResult.FemalesUnder5,
                    parsingResult.FemalesAged5AndOlder,
                    message.Sent
                );                
                return;
            }

            caseReporting.Report(
                dataCollector.Id,
                healthRiskId,
                message.OriginNumber,
                parsingResult.MalesUnder5,
                parsingResult.MalesAged5AndOlder,
                parsingResult.FemalesUnder5,
                parsingResult.FemalesAged5AndOlder,
                dataCollector.Location.Longitude,
                dataCollector.Location.Latitude,
                message.Sent);
        }           
    }
}