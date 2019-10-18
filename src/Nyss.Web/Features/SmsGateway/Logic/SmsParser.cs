using System;
using System.Linq;
using System.Text.RegularExpressions;
using Nyss.Web.Features.SmsGateway.Logic.Models;

namespace Nyss.Web.Features.SmsGateway.Logic
{
    public class SmsParser : ISmsParser
    {
        public Case ParseSmsToCase(string smsText)
        {
            var parsedCase = new Case
            {
                IsValid = true
            };

            var singlePattern = new Regex(@"^(?<healthRiskCode>\d+)#(?<genderCode>\d+)#(?<ageCode>\d+)$");
            var aggregatePattern = new Regex(@"^(?<healthRiskCode>\d+)#(?<malesBelowFive>\d+)#(?<malesAtLeastFive>\d+)#(?<femalesBelowFive>\d+)#(?<femalesAtLeastFive>\d+)$");

            if (singlePattern.IsMatch(smsText))
            {
                var matches = singlePattern.Match(smsText);
                var healthRiskCode = int.Parse(matches.Groups["healthRiskCode"].Value);
                var genderCode = int.Parse(matches.Groups["genderCode"].Value);
                var ageCategoryCode = int.Parse(matches.Groups["ageCode"].Value);

                if (healthRiskCode < 0)
                {
                    parsedCase.IsValid = false;
                }

                if (!IsDefined<Gender>(genderCode))
                {
                    parsedCase.IsValid = false;
                }

                if (!IsDefined<AgeCategory>(ageCategoryCode))
                {
                    parsedCase.IsValid = false;
                }

                if (parsedCase.IsValid)
                {
                    var gender = (Gender) genderCode;
                    var ageCategory = (AgeCategory) ageCategoryCode;

                    parsedCase.IsSingle = true;
                    parsedCase.HealthRiskCode = healthRiskCode;
                    parsedCase.CountFemalesAtLeastFive = gender == Gender.Female && ageCategory == AgeCategory.AtLeastFive ? 1 : 0;
                    parsedCase.CountFemalesBelowFive = gender == Gender.Female && ageCategory == AgeCategory.BelowFive ? 1 : 0;
                    parsedCase.CountMalesAtLeastFive = gender == Gender.Male && ageCategory == AgeCategory.AtLeastFive ? 1 : 0;
                    parsedCase.CountMalesBelowFive = gender == Gender.Male && ageCategory == AgeCategory.BelowFive ? 1 : 0;
                }
            }
            else if (aggregatePattern.IsMatch(smsText))
            {
                var matches = aggregatePattern.Match(smsText);
                var healthRiskCode = int.Parse(matches.Groups["healthRiskCode"].Value);
                var countFemalesAtLeastFive = int.Parse(matches.Groups["femalesAtLeastFive"].Value);
                var countFemalesBelowFive = int.Parse(matches.Groups["femalesBelowFive"].Value);
                var countMalesAtLeastFive = int.Parse(matches.Groups["malesAtLeastFive"].Value);
                var countMalesBelowFive = int.Parse(matches.Groups["malesBelowFive"].Value);

                if (healthRiskCode < 0)
                {
                    parsedCase.IsValid = false;
                }

                if (countFemalesAtLeastFive < 0
                    || countFemalesBelowFive < 0
                    || countMalesAtLeastFive < 0
                    || countMalesBelowFive < 0)
                {
                    parsedCase.IsValid = false;
                }

                if (parsedCase.IsValid)
                {
                    parsedCase.IsSingle = false;
                    parsedCase.HealthRiskCode = healthRiskCode;
                    parsedCase.CountFemalesAtLeastFive = countFemalesAtLeastFive;
                    parsedCase.CountFemalesBelowFive = countFemalesBelowFive;
                    parsedCase.CountMalesAtLeastFive = countMalesAtLeastFive;
                    parsedCase.CountMalesBelowFive = countMalesBelowFive;
                }
            }
            else
            {
                parsedCase.IsValid = false;
            }

            return parsedCase;
        }

        private bool IsDefined<TEnum>(int value) where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an enumerated type");
            }

            var values = Enum.GetValues(typeof(TEnum)).Cast<int>().OrderBy(x => x);

            return values.Contains(value);
        }
    }
}