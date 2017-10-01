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
                return new CaseReport
                {
                    HealthRiskId = numbers[0],
                    Sex = (Sex)numbers[1],
                    Age = numbers[2]
                };
            }
            throw new Exception("Sms should only have 3 numbers");
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

    public class CaseReport
    {
        public int HealthRiskId { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
    }

    public enum Sex
    {
        Male = 1,
        Female = 2
    }
}