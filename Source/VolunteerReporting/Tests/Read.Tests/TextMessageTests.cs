using System;
using System.Linq;
using Xunit;
using Read.TextMessageRecievedFeatures;
using Read.Tests.Mockups;
using Events;
using FakeItEasy;
using Infrastructure.Application;

namespace Read.Tests
{
    public class TextMessageTests
    {
        [Fact]
        public void ZeroReportShouldResultInStandardCaseReport()
        {
            // arrange
            var eventEmitter = A.Fake<Infrastructure.Events.IEventEmitter>();
            var dataCollectors = A.Fake<IDataCollectors>();
            var healthRiskFeatures = A.Fake<HealthRiskFeatures.IHealthRisks>();

            // act
            string textMessage = $"41#0#0";
            TextMessageRecievedRaiseCaseReportsEventsProcessor processor = new TextMessageRecievedRaiseCaseReportsEventsProcessor(eventEmitter, dataCollectors, healthRiskFeatures);
            processor.Process(new Events.External.TextMessageReceived()
            {
                Id = Guid.NewGuid(),
                Keyword = "",
                Latitude = 32.0,
                Longitude = 21.0,
                Message = textMessage,
                OriginNumber = "12345678",
                ReceivedAtGatewayNumber = "000000000",
                Sent = DateTimeOffset.Now
            });

            // Assert we have one CaseReportReceived event emitted, for the zero report
            A.CallTo(eventEmitter)
                .Where(call => call.Method.Name == "Emit")
                .WhenArgumentsMatch(x => {
                    var @event = x.Get<CaseReportReceived>("event") as CaseReportReceived;
                    return
                        x.Get<Feature>("feature") == TextMessageRecievedRaiseCaseReportsEventsProcessor.Feature &&
                        @event != null &&
                        @event.NumberOfFemalesOver5 == 0 &&
                        @event.NumberOfFemalesUnder5 == 0 &&
                        @event.NumberOfMalesOver5 == 0 &&
                        @event.NumberOfMalesUnder5 == 0;
                })
                .MustHaveHappened();

            // Assert there are no other events
            A.CallTo(eventEmitter)
                .Where(call => call.Method.Name == "Emit")
                .WhenArgumentsMatch(x => x.Get<Feature>("feature") != TextMessageRecievedRaiseCaseReportsEventsProcessor.Feature)
                .MustNotHaveHappened();
        }
    }
}
