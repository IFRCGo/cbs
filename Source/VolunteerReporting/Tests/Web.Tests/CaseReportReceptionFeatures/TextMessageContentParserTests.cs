using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Web.Features.CaseReportReceptionFeatures
{
    public class TextMessageContentParserTests
    {
        [Theory]
        [InlineData("0 # 1 # 15", 0, "Male", 15)]
        [InlineData("1#2#4", 1, "Female", 4)]
        [InlineData("  3    #  1# 20     ", 3, "Male", 20)]
        public void GivenValidTextMessageWithSingleCaseReport_MessageParsedToSingleCaseReport(
            string inputText,
            int expectedHealthRiskId,
            string expectedGender,
            int expectedAge)
        {
            var result = TextMessageContentParser.Parse(inputText) as SingleCaseReportContent;
            Assert.Equal(expectedHealthRiskId, result.HealthRiskId);
            Assert.Equal(expectedGender, result.Sex.ToString());
            Assert.Equal(expectedAge, result.Age);            
        }

        [Theory]
        [InlineData(" #  # ")]
        [InlineData("#1#2#4")]
        [InlineData("1#2#4#")]
        [InlineData("1#2##4")]
        [InlineData("hello world!")]
        [InlineData("123")]
        public void GivenInvalidTextMessageWithSingleCaseReport_InvalidContenReturned(string inputText)
        {
            var result = TextMessageContentParser.Parse(inputText) as InvalidCaseReportContent;
            Assert.True(result.GetType() == typeof(InvalidCaseReportContent));
        }

        [Theory]
        [InlineData("0 # 1 # 15 # 0 # 2", 0, 1, 15, 0, 2)]
        [InlineData("1#2#4#0#5", 1, 2, 4, 0, 5)]
        [InlineData("  3    #  1# 20     #3#6", 3, 1, 20, 3, 6)]
        public void GivenValidTextMessageWithSeveralCaseReports_MessageParsedToMultipleCaseReport(
            string inputText,
            int expectedHealthRiskId,
            int expectedMaleFiveOrUnder,
            int expectedMaleOverFive,
            int expectedFemaleFiveOrUnder,
            int expectedFemaleOverFive
            )
        {
            var result = TextMessageContentParser.Parse(inputText) as MultipleCaseReportContent;
            Assert.Equal(expectedHealthRiskId, result.HealthRiskId);
            Assert.Equal(expectedMaleFiveOrUnder, result.MalesUnder5);
            Assert.Equal(expectedMaleOverFive, result.MalesOver5);
            Assert.Equal(expectedFemaleFiveOrUnder, result.FemalesUnder5);
            Assert.Equal(expectedFemaleOverFive, result.FemalesOver5);
        }
    }
}
