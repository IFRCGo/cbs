/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;

namespace Web.Features.CaseReportReceptionFeatures
{
    /// summary
    /// Parse the content of Case Reports sent by SMS
    /// summary
    public class TextMessageContentParser
    {    
        public static CaseReportContent Parse(string text)
        {
            // expected format of sms content: Event # sex of case # Age of case #
            //or Event	# Number of male cases five or under # Number of male cases over 5	# Number of female cases five or under # Number of female cases over five
            var fragments = text.Replace(" ", string.Empty).Split('#');

            if(fragments.Any(x => string.IsNullOrEmpty(x)))
            {
                return new InvalidCaseReportContent
                {
                    ErrorMessage = "Message contain one or more hashes with missing number in front or after"
                };
            }
            // pick out numbers in textMessage content
            var numbers = fragments.Where(f => IsNum(f)).Select(o => ToNum(o)).ToList();

            if (numbers.Count == 3)
            {
                return new SingleCaseReportContent
                {
                    HealthRiskId = numbers[0],
                    Sex = (Sex)numbers[1],
                    Age = numbers[2]
                };
            }
            else if (numbers.Count == 5)
            {
                return new MultipleCaseReportContent
                {
                    HealthRiskId = numbers[0],
                    MalesUnder5 = numbers[1],
                    MalesOver5 = numbers[2],
                    FemalesUnder5 = numbers[3],
                    FemalesOver5 = numbers[4]
                };
            }

            return new InvalidCaseReportContent();
        }        

        private static bool IsNum(string input)
        {
            return int.TryParse(input, out int num);
        }

        private static int ToNum(string input)
        {
            return int.Parse(input);
        }
    }

    public abstract class CaseReportContent
    {        
    }

    public class MultipleCaseReportContent : CaseReportContent
    {
        public int HealthRiskId { get; set; }
        public int FemalesUnder5 { get; set; }
        public int FemalesOver5 { get; set; }
        public int MalesUnder5 { get; set; }
        public int MalesOver5 { get; set; }
    }

    public class SingleCaseReportContent : CaseReportContent
    {
        public int HealthRiskId { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
    }

    public class InvalidCaseReportContent : CaseReportContent
    {
        public string ErrorMessage { get; set; } = "Text message should contain 3 or 5 numbers, separated by hashes (#). Ex: 1#3#5 or 1#3#0#4#4";
    }

    public enum Sex
    {
        Male = 1,
        Female = 2
    }     
}