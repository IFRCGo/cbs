/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Machine.Specifications;
using Policies.Reporting.Notifications;

namespace Policies.Specs.Reporting.Notifications.when_receiving_a_notification
{
    [Subject("Notification")]
    public class with_valid_case_report_for_female_aged_5_and_older
    {
        private static NotificationParsingResult notificationParsingResult;
        private static IEnumerable<NotificationFragment> notification;
        private static bool validation_results;

        private static bool is_invalid_format;
        private static bool is_single_case_report;
        private static bool is_non_human_case_report;
        private static bool is_multiple_case_report;

        private static int females_aged_5_and_older;
        private static int males_aged_5_and_older;
        private static int females_under_5;
        private static int males_under_5;

        Establish context = () =>
        {
            notification = given.a_notification_builder.get_valid_notification_aged_5_and_older();
            notificationParsingResult = new NotificationParsingResult(notification);
        };

        Because of = () =>
        {
            validation_results = notificationParsingResult.IsValid;

            females_aged_5_and_older = notificationParsingResult.FemalesAged5AndOlder;
            males_aged_5_and_older = notificationParsingResult.MalesAged5AndOlder;
            females_under_5 = notificationParsingResult.FemalesUnder5;
            males_under_5 = notificationParsingResult.MalesUnder5;

            is_invalid_format = notificationParsingResult.IsInvalidFormat;
            is_single_case_report = notificationParsingResult.IsSingleCaseReport;
            is_non_human_case_report = notificationParsingResult.IsNonHumanCaseReport;
            is_multiple_case_report = notificationParsingResult.IsMultipleCaseReport;
        };

        It should_be_a_valid_case_report = () =>
        {
            validation_results.ShouldBeTrue();

            is_invalid_format.ShouldBeFalse();
            is_single_case_report.ShouldBeTrue();
            is_non_human_case_report.ShouldBeFalse();
            is_multiple_case_report.ShouldBeFalse();
        };
        It should_be_female_aged_5_and_older = () =>
        {
            females_aged_5_and_older.ShouldBeLike(1);
            males_aged_5_and_older.ShouldBeLike(0);
            females_under_5.ShouldBeLike(0);
            males_under_5.ShouldBeLike(0);
        };
    }
}