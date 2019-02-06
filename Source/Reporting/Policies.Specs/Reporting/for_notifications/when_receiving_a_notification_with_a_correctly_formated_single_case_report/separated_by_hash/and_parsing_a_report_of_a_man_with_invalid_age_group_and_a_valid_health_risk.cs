/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Events.NotificationGateway.Reporting.SMS;
using Machine.Specifications;
using Policies.Reporting.Notifications;

namespace Policies.Specs.Reporting.for_notifications.when_receiving_a_notification_with_a_correctly_formated_single_case_report.separated_by_hash
{
    [Subject("Notification")]
    public class and_parsing_a_report_of_a_man_with_invalid_age_group_and_a_valid_health_risk : given.a_text_message_received_builder
    {
        static readonly bool is_female = false;

        static readonly NotificationParser parser = new NotificationParser();
        static TextMessageReceived received_text_message;
        static NotificationParsingResult result;
        Establish context = () => received_text_message = get_text_message_received_with_invalid_age_group(is_female);
        
        Because of = () => result = parser.Parse(received_text_message);

        It should_not_be_a_valid_case_report = () => result.IsValid.ShouldBeFalse();
        It should_have_one_error_messages = () => result.ErrorMessages.Count.ShouldEqual(1);
        It should_not_be_a_valid_format = () => result.IsInvalidFormat.ShouldBeTrue();
    }
}