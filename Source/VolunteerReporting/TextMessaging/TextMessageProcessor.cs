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
                ReportInvalidReportFromUnknownDataCollector(message, parsingResult.ErrorMessages, caseReporting);
                return;                
            }

            if (!isTextMessageFormatValid && !unknownDataCollector)
            {
                ReportInvalidMessage(message, parsingResult.ErrorMessages, dataCollector, caseReporting);
                return;
            }
            
            var healthRiskReadableId = parsingResult.Numbers[0];
            var healthRiskId = _healthRisks.GetIdFromReadableId(healthRiskReadableId);
            if (healthRiskId == Guid.Empty)
            {
                var errorMessages = new List<string> { $"Unable to find health risk, since there are no health risks with a readable id of {healthRiskReadableId}" };
                if (unknownDataCollector)
                {
                    ReportInvalidReportFromUnknownDataCollector(
                        message,
                        errorMessages,
                        caseReporting
                        );
                    return;
                }
                else
                {
                    ReportInvalidMessage(
                    message,
                    errorMessages,
                    dataCollector,
                    caseReporting);
                    return;
                }               
            }

            var malesAges0To4 = 0;
            var malesAgedOver4 = 0;
            var femalesAges0To4 = 0;
            var femalesAgedOver4 = 0;

            if (parsingResult.HasMultipleCases)
            {
                malesAges0To4 = parsingResult.Numbers[1];
                malesAgedOver4 = parsingResult.Numbers[2];
                femalesAges0To4 = parsingResult.Numbers[3];
                femalesAgedOver4 = parsingResult.Numbers[4];                     
            }
            //TODO: Add validation on health risk to ensure that human health risks actually have three valid numbers. Non-human health risks are single digit
            var singlecaseWithHumanHealthRisk = parsingResult.Numbers.Length == 3;
            if (singlecaseWithHumanHealthRisk)
            {
                var sex = (Sex)parsingResult.Numbers[1];
                var ageGroup = parsingResult.Numbers[2];
                malesAges0To4 = ageGroup == 1 && sex == Sex.Male ? 1 : 0;
                malesAgedOver4 = ageGroup == 2 && sex == Sex.Male ? 1 : 0;
                femalesAges0To4 = ageGroup == 1 && sex == Sex.Female ? 1 : 0;
                femalesAgedOver4 = ageGroup == 2 && sex == Sex.Female ? 1 : 0;
            }

            if (unknownDataCollector)
            {
                ReportFromUnknownDataCollector(
                    message,
                    caseReporting,
                    healthRiskId,
                    malesAges0To4,
                    malesAgedOver4,
                    femalesAges0To4,
                    femalesAgedOver4
                    );
                return;
            }
            else
            {
                Report(
                message,
                dataCollector,
                caseReporting,
                healthRiskId,
                malesAges0To4,
                malesAgedOver4,
                femalesAges0To4,
                femalesAgedOver4);
                return;
            }
        }

        private void ReportInvalidReportFromUnknownDataCollector(
            TextMessage message,
            IEnumerable<string> errorMessages,
            CaseReporting caseReporting)
        {
            caseReporting.ReportInvalidReportFromUnknownDataCollector(
                message.OriginNumber,
                message.Message,
                errorMessages,
                message.Sent);
        }

        private void ReportInvalidMessage(
            TextMessage message,
            IEnumerable<string> errorMessages,
            DataCollector dataCollector,
            CaseReporting caseReporting)
        {           
                caseReporting.ReportInvalidReport(
                dataCollector.Id,
                message.OriginNumber,
                message.Message,
                errorMessages,
                message.Sent);            
        }

        private void ReportFromUnknownDataCollector(
            TextMessage message,
            CaseReporting caseReporting,
            Guid healthRiskId,
            int malesAges0To4,
            int malesAgedOver4,
            int femalesAges0To4,
            int femalesAgedOver4)
        {
            caseReporting.ReportFromUnknownDataCollector(
                    message.OriginNumber,
                    healthRiskId,
                    malesAges0To4,
                    malesAgedOver4,
                    femalesAges0To4,
                    femalesAgedOver4,
                    message.Sent
                );
        }

        private void Report(
            TextMessage message,
            DataCollector dataCollector,
            CaseReporting caseReporting,
            Guid healthRiskId,
            int malesAges0To4,
            int malesAgedOver4,
            int femalesAges0To4,
            int femalesAgedOver4)
        {           
            caseReporting.Report(
                dataCollector.Id,
                healthRiskId,
                message.OriginNumber,
                malesAges0To4,
                malesAgedOver4,
                femalesAges0To4,
                femalesAgedOver4,
                dataCollector.Location.Longitude,
                dataCollector.Location.Latitude,
                message.Sent
            );                        
        }
    }
}