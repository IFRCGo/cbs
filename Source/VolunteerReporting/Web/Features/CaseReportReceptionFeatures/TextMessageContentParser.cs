/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Web.Features.CaseReportReceptionFeatures
{
    /// summary
    /// Parse the content of Case Reports sent by SMS
    /// summary
    public class TextMessageContentParser
    {
        //TODO: Add tests that verify the parsing
        public static CaseReportContent Parse(string text)
        {
            // expected format of sms content: Event # sex of case # Age of case #
            var fragments = text.Split(' ');

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

            throw new Exception("Text message should contain 3 or 5 numbers");
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
        public int HealthRiskId { get; set; }
    }

    public class MultipleCaseReportContent : CaseReportContent
    {
        public int FemalesUnder5 { get; set; }
        public int FemalesOver5 { get; set; }
        public int MalesUnder5 { get; set; }
        public int MalesOver5 { get; set; }
    }

    public class SingleCaseReportContent : CaseReportContent
    {
        public Sex Sex { get; set; }
        public int Age { get; set; }
    }

    public enum Sex
    {
        Male = 1,
        Female = 2
    }     
}