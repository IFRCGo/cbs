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
            var dataCollector = _dataCollectors.GetByPhoneNumber(message.OriginNumber);
            var caseReportId = Guid.NewGuid();
            var caseReporting = _caseReportingRepository.Get(caseReportId);
            if (!parsingResult.IsValid)
            {
                ReportInvalidMessage(message, parsingResult.ErrorMessages, dataCollector, caseReporting, message.Sent);
                return;
            }
            var healthRiskReadableId = parsingResult.Numbers[0];
            var healthRiskId = _healthRisks.GetIdFromReadableId(healthRiskReadableId);
            if (healthRiskId == Guid.Empty)
            {                  
                ReportInvalidMessage(
                    message,
                    new List<string> {$"Unable to find health risk, since there are no health risks with a readable id of {healthRiskReadableId}"},
                    dataCollector,
                    caseReporting,
                    message.Sent);
                return;
            }

            if (!parsingResult.HasMultipleCases)
            {
                var malesAges0To4 = 0;
                var malesAgedOver4 = 0;
                var femalesAges0To4 = 0;
                var femalesAgedOver4 = 0;
                if (parsingResult.Numbers.Length == 3)
                {  
                    var sex = (Sex)parsingResult.Numbers[1];
                    var ageGroup = parsingResult.Numbers[2];                        
                    malesAges0To4 = ageGroup == 1 && sex == Sex.Male ? 1 : 0;
                    malesAgedOver4 = ageGroup == 2 && sex == Sex.Male ? 1 : 0;
                    femalesAges0To4 = ageGroup == 1 && sex == Sex.Female ? 1 : 0;
                    femalesAgedOver4 = ageGroup == 2 && sex == Sex.Female ? 1 : 0;                                     
                }                
                Report(
                    message,
                    dataCollector,
                    caseReporting,
                    healthRiskId,
                    malesAges0To4,
                    malesAgedOver4,
                    femalesAges0To4,
                    femalesAgedOver4,
                    message.Sent);
            }
            else
            {
                var malesAges0To4 = parsingResult.Numbers[1];
                var malesAgedOver4 = parsingResult.Numbers[2];
                var femalesAges0To4 = parsingResult.Numbers[3];
                var femalesAgedOver4 = parsingResult.Numbers[4];
                Report(
                    message,
                    dataCollector,
                    caseReporting,
                    healthRiskId,
                    malesAges0To4,
                    malesAgedOver4,
                    femalesAges0To4,
                    femalesAgedOver4,
                    message.Sent);
            }
        }

        void ReportInvalidMessage(
            TextMessage message,
            IEnumerable<string> errorMessages,
            DataCollector dataCollector,
            CaseReporting caseReporting,
            DateTimeOffset timestamp)
        {
            if (dataCollector != null)
                caseReporting.ReportInvalidReport(
                dataCollector.Id,
                message.OriginNumber,
                message.Message,
                errorMessages,
                timestamp);
            else caseReporting.ReportInvalidReportFromUnknownDataCollector(
                message.OriginNumber,
                message.Message,
                errorMessages,
                timestamp);
        }

        void Report(
            TextMessage message,
            DataCollector dataCollector,
            CaseReporting caseReporting,
            Guid healthRiskId,
            int malesUnder5,
            int malesOver5,
            int femalesUnder5,
            int femalesOver5,
            DateTimeOffset timestamp)
        {
            if (dataCollector != null)
            {
                caseReporting.Report(
                    dataCollector.Id,
                    healthRiskId,
                    message.OriginNumber,
                    malesUnder5,
                    malesOver5,
                    femalesUnder5,
                    femalesOver5,
                    dataCollector.Location.Longitude,
                    dataCollector.Location.Latitude,
                    timestamp
                );
            }
            else
            {
                caseReporting.ReportFromUnknownDataCollector(
                    message.OriginNumber,
                    healthRiskId,
                    malesUnder5,
                    malesOver5,
                    femalesUnder5,
                    femalesOver5,
                    timestamp
                );
            }
        }
    }
}