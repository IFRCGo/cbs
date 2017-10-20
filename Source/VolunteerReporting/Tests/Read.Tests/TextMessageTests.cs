using System;
using Xunit;
using Read.TextMessageRecievedFeatures;
using Read.Tests.Mockups;
using Events;

namespace Read.Tests
{
    public class TextMessageTests
    {
        [Fact]
        public void ZeroReportShouldResultInStandardCaseReport()
        {
            var eventEmitter = new MockupEventEmitter();
            var dataCollectors = new MockupDataCollectors();
            var healthRiskFeatures = new MockupHealthRiskFeatures();

            int healthRiskReadableId = 41;
            string textMessage = $"{healthRiskReadableId}#0#0";

            TextMessageRecievedRaiseCaseReportsEventsProcessor procesor = new TextMessageRecievedRaiseCaseReportsEventsProcessor(eventEmitter, dataCollectors, healthRiskFeatures);

            procesor.Process(new Events.External.TextMessageReceived()
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

            var result = eventEmitter.PopFirst();

            
            // There should not be any other events
            Assert.Throws<InvalidOperationException>(() => eventEmitter.PopFirst());

            Assert.Equal(result.feature, TextMessageRecievedRaiseCaseReportsEventsProcessor.Feature);
            Assert.IsType<CaseReportReceived>(result.@event);

            var caseReport = (CaseReportReceived)result.@event;
            Assert.Equal(0, caseReport.NumberOfFemalesOver5);
            Assert.Equal(0, caseReport.NumberOfFemalesUnder5);
            Assert.Equal(0, caseReport.NumberOfMalesOver5);
            Assert.Equal(0, caseReport.NumberOfMalesUnder5);
        }
    }
}
