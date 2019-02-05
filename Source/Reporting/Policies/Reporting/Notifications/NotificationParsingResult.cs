/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using Concepts.CaseReports;
using Concepts.DataCollectors;
using Concepts.HealthRisks;

namespace Policies.Reporting.Notifications
{
    internal enum CaseReportType
    {
        InvalidFormat,
        NonHuman,
        Single,
        Multiple
    }

    public class NotificationParsingResult
    {
        private int[] numbers;

        private CaseReportType caseReportType = CaseReportType.InvalidFormat;

        public IList<NotificationFragment> Fragments { get; }

        public IList<string> ErrorMessages { get; }
            = new List<string>();

        public HealthRiskReadableId HealthRiskReadableId { get; private set; }

        public int MalesUnder5 { get; private set; }
        public int MalesAged5AndOlder { get; private set; }
        public int FemalesUnder5 { get; private set; }
        public int FemalesAged5AndOlder { get; private set; }

        public NotificationParsingResult(IEnumerable<NotificationFragment> fragments)
        {
            Fragments = fragments.ToList();
            ValidateAllFragmentsHasValidValue();

            if (!IsValid)
                return;

            // Only validate further when all the fragments are only numbers
            SetCaseReportType();
            SetNumbers();
            ValidateMessage();
            PopulateMessageContent();
        }

        public bool IsInvalidFormat => caseReportType == CaseReportType.InvalidFormat;
        public bool IsNonHumanCaseReport => caseReportType == CaseReportType.NonHuman;
        public bool IsSingleCaseReport => caseReportType == CaseReportType.Single;
        public bool IsMultipleCaseReport => caseReportType == CaseReportType.Multiple;

        public bool IsValid => !ErrorMessages.Any();

        private void ValidateAllFragmentsHasValidValue()
        {
            if (Fragments.Any(fragment => !fragment.IsValid))
                ErrorMessages.Add("Message contain one or more hashes with missing number in front.");
        }

        private void SetCaseReportType()
        {
            switch (Fragments.Count)
            {
                case 1:
                    caseReportType = CaseReportType.NonHuman;
                    break;
                case 3:
                    caseReportType = CaseReportType.Single;
                    break;
                case 5:
                    caseReportType = CaseReportType.Multiple;
                    break;
                default:
                    caseReportType = CaseReportType.InvalidFormat;
                    break;
            }
        }

        private void SetNumbers()
        {
            numbers = Fragments.Where(f => f.Number.HasValue).Select(f => f.Number.Value).ToArray();

        }

        private void ValidateMessage()
        {
            if (!IsValid)
                return;

            if (IsInvalidFormat)
            {
                ErrorMessages.Add("Message is in incorrect format - it should have 1, 3 or 5 numbers");
            }

            if (!IsInvalidFormat && numbers.Any(x => x < 0))
            {
                ErrorMessages.Add("Negative numbers are incorrect - only positive numbers and zero is allowed");
            }

            if (IsSingleCaseReport) // Don't check if it's not a valid CaseReport
            {
                bool AgeGroupIsValid()
                {
                    return Enum.IsDefined(typeof(AgeGroup), numbers[2]);
                }
                bool SexIsValid()
                {
                    return Enum.IsDefined(typeof(Sex), numbers[1]);
                }

                if (!AgeGroupIsValid())
                {
                    ErrorMessages.Add(
                        $"Age group must be either under 5 ({(int)AgeGroup.AgeUnder5}), or 5 and over ({(int)AgeGroup.Age5AndOver})");
                }

                if (!SexIsValid())
                {
                    ErrorMessages.Add(
                        $"Sex must be either Male ({(int)Sex.Male}), or Female ({(int)Sex.Female})");
                }
            }
        }

        private void PopulateMessageContent()
        {
            if (!IsValid)
                return;

            HealthRiskReadableId = numbers[0];

            if (IsNonHumanCaseReport)
                return;

            if (IsSingleCaseReport)
            {
                var sex = (Sex)numbers[1];
                var ageGroup = (AgeGroup)numbers[2];

                MalesUnder5 = ageGroup == AgeGroup.AgeUnder5 && sex == Sex.Male ? 1 : 0;
                MalesAged5AndOlder = ageGroup == AgeGroup.Age5AndOver && sex == Sex.Male ? 1 : 0;
                FemalesUnder5 = ageGroup == AgeGroup.AgeUnder5 && sex == Sex.Female ? 1 : 0;
                FemalesAged5AndOlder = ageGroup == AgeGroup.Age5AndOver && sex == Sex.Female ? 1 : 0;
            }

            if (IsMultipleCaseReport)
            {
                MalesUnder5 = numbers[1];
                MalesAged5AndOlder = numbers[2];
                FemalesUnder5 = numbers[3];
                FemalesAged5AndOlder = numbers[4];
            }
        }
    }
}