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
    }
}
