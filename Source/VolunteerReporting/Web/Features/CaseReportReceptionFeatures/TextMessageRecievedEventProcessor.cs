/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Events;
using Events.External;
using Infrastructure.Application;
using Infrastructure.Events;
using System;

namespace Web.Features.CaseReportReceptionFeatures
{
    //TODO: Is the web project the right places for this? Processing the TextMessageReceived event is kinda like a command, and an event is only emited if its a valid message
    public class TextMessageRecievedEventProcessor : Infrastructure.Events.IEventProcessor
    {
        public static readonly Feature Feature = "CaseReportReception";
        private readonly IEventEmitter _eventEmitter;

        public TextMessageRecievedEventProcessor(IEventEmitter eventEmitter)
        {
            _eventEmitter = eventEmitter;
        }

        //TODO: Add a test that ensure that the right count is put in the right property
        public void Process(TextMessageReceived @event)
        {
            //TODO: Handle if parsing fails and send TextMessageParseFailed event  
            var caseReportContent = TextMessageContentParser.Parse(@event.Message);
            //TODO: Determine which properties are needed on event CaseReportReceived
            //TODO: Should all cases be converted to single cases or sepperate event for multiple cases?
            
            if(caseReportContent.GetType() == typeof(SingleCaseReportContent))
            {
                var singlecaseReport = caseReportContent as SingleCaseReportContent;
                _eventEmitter.Emit(Feature, new CaseReportReceived
                {
                    Id = Guid.NewGuid(),
                    DataCollectorId = Guid.NewGuid(), //TODO: Find datacollector. Should we suppoort unkown? Optional?
                    HealthRiskId = Guid.NewGuid(), //TODO: Must map from code to Guid
                    NumberOfFemalesUnder5 = 
                    singlecaseReport.Age <= 5 && singlecaseReport.Sex == Sex.Female ? 1 : 0,
                    NumberOfFemalesOver5 =
                    singlecaseReport.Age > 5 && singlecaseReport.Sex == Sex.Female ? 1 : 0,
                    NumberOfMalesUnder5 =
                    singlecaseReport.Age <= 5 && singlecaseReport.Sex == Sex.Male ? 1 : 0,
                    NumberOfMalesOver5 =
                    singlecaseReport.Age > 5 && singlecaseReport.Sex == Sex.Male ? 1 : 0,
                    NumberOfOthersUnder5 =
                    singlecaseReport.Age <= 5 && singlecaseReport.Sex == Sex.Other ? 1 : 0,
                    NumberOfOthersOver5 =
                    singlecaseReport.Age > 5 && singlecaseReport.Sex == Sex.Other ? 1 : 0,
                    Latitude = @event.Latitude,
                    Longitude = @event.Longitude,
                    Timestamp = @event.Sent
                });
            }
            if (caseReportContent.GetType() == typeof(MultipleCaseReportContent))
            {
                throw new NotImplementedException();
            }
            else
            {
                //TODO: Should we throw exception for unknown type? Should not happen. Log it?
            }            
        }
    }    
}
