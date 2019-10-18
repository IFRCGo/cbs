using System;
using System.Text.RegularExpressions;
using Nyss.Web.Features.SmsGateway.Logic.Models;

namespace Nyss.Web.Features.SmsGateway.Logic
{
    public class SmsParser : ISmsParser
    {
        public Case ParseSmsToCase(string smsText)
        {   
            var parsedCase = new Case();

            var singlePattern = new Regex(@"(?<healthRiskCode>\d+)#(?<genderCode>\d+)#(?<ageCode>\d+)");

            if (singlePattern.IsMatch(smsText))
            {
                var matches = singlePattern.Match(smsText);
                var healthRiskCode = int.Parse(matches.Groups["healthRiskCode"].Value);

                if(healthRiskCode < 0)
                {
                    parsedCase.IsValid = false;
                }

                if (!Enum.TryParse<Gender>(matches.Groups["genderCode"].Value, out var gender))
                {
                    parsedCase.IsValid = false;
                }
                
                if (!Enum.TryParse<AgeCategory>(matches.Groups["ageCode"].Value, out var ageCategory))
                {
                    parsedCase.IsValid = false;
                }

                if (parsedCase.IsValid)
                {
                    parsedCase.IsSingle = true;
                    parsedCase.HealthRiskCode = healthRiskCode;
                    parsedCase.CountFemalesAtLeastFive = gender == Gender.Female && ageCategory == AgeCategory.AtLeastFive ? 1 : 0;
                    parsedCase.CountFemalesBelowFive = gender == Gender.Female && ageCategory == AgeCategory.BelowFive ? 1 : 0;
                    parsedCase.CountMalesAtLeastFive = gender == Gender.Male && ageCategory == AgeCategory.AtLeastFive ? 1 : 0;
                    parsedCase.CountMalesBelowFive = gender == Gender.Male && ageCategory == AgeCategory.BelowFive ? 1 : 0;
                } 
            }

            return parsedCase;
        }
    }
}
