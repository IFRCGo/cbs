using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Features.CaseReportReceptionFeatures
{
    [TestClass]
    public class TextMessageContentParserTests
    {        
        [DataTestMethod]
        [DataRow("0 # 1 # 15", 0, "Male", 15)]
        [DataRow("1#2#4", 1, "Female", 4)]
        [DataRow("  3    #  1# 20     ", 3, "Male", 20)]
        public void GivenValidTextMessageWithSingleCaseReport_MessageParsedToSingleCaseReport(
            string inputText,
            int expectedHealthRiskId,
            string expectedGender,
            int expectedAge)
        {
            var result = TextMessageContentParser.Parse(inputText) as SingleCaseReportContent;
            Assert.AreEqual(expectedHealthRiskId, result.HealthRiskId);
            Assert.AreEqual(expectedGender, result.Sex.ToString());
            Assert.AreEqual(expectedAge, result.Age);            
        }

        [DataTestMethod]
        [DataRow(" #  # ")]
        [DataRow("#1#2#4")]
        [DataRow("1#2#4#")]
        [DataRow("1#2##4")]
        [DataRow("hello world!")]
        [DataRow("123")]
        public void GivenInvalidTextMessageWithSingleCaseReport_InvalidContenReturned(string inputText)
        {
            var result = TextMessageContentParser.Parse(inputText) as InvalidCaseReportContent;
            Assert.IsTrue(result.GetType() == typeof(InvalidCaseReportContent));
        }

        [DataTestMethod]
        [DataRow("0 # 1 # 15 # 0 # 2", 0, 1, 15, 0, 2)]
        [DataRow("1#2#4#0#5", 1, 2, 4, 0, 5)]
        [DataRow("  3    #  1# 20     #3#6", 3, 1, 20, 3, 6)]
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
            Assert.AreEqual(expectedHealthRiskId, result.HealthRiskId);
            Assert.AreEqual(expectedMaleFiveOrUnder, result.MalesUnder5);
            Assert.AreEqual(expectedMaleOverFive, result.MalesOver5);
            Assert.AreEqual(expectedFemaleFiveOrUnder, result.FemalesUnder5);
            Assert.AreEqual(expectedFemaleOverFive, result.FemalesOver5);
        }
    }
}
