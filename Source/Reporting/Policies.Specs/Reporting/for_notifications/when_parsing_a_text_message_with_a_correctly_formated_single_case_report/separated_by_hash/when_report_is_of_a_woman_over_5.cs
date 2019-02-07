/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Events.NotificationGateway.Reporting.SMS;
using Machine.Specifications;
using Policies.Reporting.Notifications;

namespace Policies.Specs.Reporting.for_notifications.when_parsing_a_text_message_with_a_correctly_formated_single_case_report.separated_by_hash
{
    [Subject("Notification")]
    public class when_report_is_of_a_woman_over_5 : given.a_text_message_received_builder_for_single_case_report_separated_by_hash
    {
        static readonly bool is_female = true;
        static readonly bool age_is_under_5 = false;
        static readonly NotificationParser parser = new NotificationParser();
        static TextMessageReceived received_text_message;
        static NotificationParsingResult result;
        Establish context = () =>
        {
            received_text_message = valid_text_message_received(is_female, age_is_under_5);
        };

        Because of = () => result = parser.Parse(received_text_message);

        It should_be_a_valid_case_report = () => result.IsValid.ShouldBeTrue();
        It should_not_have_error_messages = () => result.ErrorMessages.Count.ShouldEqual(0);
        It should_be_a_valid_format = () => result.IsInvalidFormat.ShouldBeFalse();
        It should_a_human_case_report = () => result.IsNonHumanCaseReport.ShouldBeFalse();
        It should_be_a_single_case_report = () => result.IsSingleCaseReport.ShouldBeTrue();
        It should_not_be_a_multiple_case_report = () => result.IsMultipleCaseReport.ShouldBeFalse();
        It should_have_a_valid_health_risk_readable_id = () => result.HealthRiskReadableId.ShouldEqual(new Concepts.HealthRisks.HealthRiskReadableId{Value = valid_health_risk_id});
        It should_not_be_female_aged_under_5 = () => result.FemalesUnder5.ShouldEqual(0);
        It should_be_female_aged_over_5 = () => result.FemalesAged5AndOlder.ShouldEqual(1);
        It should_not_be_male_aged_under_5 = () => result.MalesUnder5.ShouldEqual(0);
        It should_not_be_male_aged_over_5 = () => result.MalesAged5AndOlder.ShouldEqual(0);
    }
}