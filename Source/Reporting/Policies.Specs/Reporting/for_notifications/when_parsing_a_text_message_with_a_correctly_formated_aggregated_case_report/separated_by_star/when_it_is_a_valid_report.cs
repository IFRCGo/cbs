/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Events.NotificationGateway.Reporting.SMS;
using Machine.Specifications;
using Policies.Reporting.Notifications;

namespace Policies.Specs.Reporting.for_notifications.when_parsing_a_text_message_with_a_correctly_formated_aggregated_case_report.separated_by_star
{
    [Subject("Notification")]
    public class when_it_is_a_valid_report : given.text_message_received_events_containing_aggregated_case_report_separated_by_star
    {
        static readonly int cases_of_male_under_5 = 0;
        static readonly int cases_of_male_over_5 = 1;
        static readonly int cases_of_female_under_5 = 2;
        static readonly int cases_of_female_over_5 = 3;
        static readonly NotificationParser parser = new NotificationParser();
        static TextMessageReceived received_text_message;
        static NotificationParsingResult result;
        Establish context = () => received_text_message = valid_text_message_received(cases_of_male_under_5, cases_of_male_over_5, cases_of_female_under_5, cases_of_female_over_5);
        
        Because of = () => result = parser.Parse(received_text_message);

        It should_be_a_valid_case_report = () => result.IsValid.ShouldBeTrue();
        It should_not_have_error_messages = () => result.ErrorMessages.Count.ShouldEqual(0);
        It should_be_a_valid_format = () => result.IsInvalidFormat.ShouldBeFalse();
        It should_be_a_human_case_report = () => result.IsNonHumanCaseReport.ShouldBeFalse();
        It should_not_be_a_single_case_report = () => result.IsSingleCaseReport.ShouldBeFalse();
        It should_be_a_multiple_case_report = () => result.IsMultipleCaseReport.ShouldBeTrue();
        It should_have_a_valid_health_risk_readable_id = () => result.HealthRiskReadableId.ShouldEqual(new Concepts.HealthRisks.HealthRiskReadableId{Value = valid_health_risk_id});
        It should_be_two_cases_of_female_under_5 = () => result.FemalesUnder5.ShouldEqual(2);
        It should_be_three_cases_of_female_over_5 = () => result.FemalesAged5AndOlder.ShouldEqual(3);
        It should_be_zero_cases_of_male_under_5 = () => result.MalesUnder5.ShouldEqual(0);
        It should_be_one_case_of_male_over_5 = () => result.MalesAged5AndOlder.ShouldEqual(1);
    }
}