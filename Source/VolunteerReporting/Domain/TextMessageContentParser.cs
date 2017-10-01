using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Domain
{
    /// summary
    /// Parse the content of Case Reports sent by SMS
    /// summary
    public class TextMessageContentParser
    {
        public static CaseReport Parse(string text)
        {
            // expected format of sms content: Event # sex of case # Age of case #
            var fragments = text.Split(' ');

            // pick out numbers in textMessage content
            var numbers = fragments.Where(f => IsNum(f)).Select(o => ToNum(o)).ToList();

            if (numbers.Count == 3)
            {
                return new SingleCaseReport
                {
                    HealthRiskId = numbers[0],
                    Sex = (Sex)numbers[1],
                    Age = numbers[2]
                };
            }
            else if (numbers.Count == 5)
            {
                return new MultipleCaseReport
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

    public abstract class CaseReport
    {
        public int HealthRiskId { get; set; }
    }

    public class MultipleCaseReport : CaseReport
    {
        public int FemalesUnder5 { get; set; }
        public int FemalesOver5 { get; set; }

        public int MalesUnder5 { get; set; }
        public int MalesOver5 { get; set; }
    }

    public class SingleCaseReport : CaseReport
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