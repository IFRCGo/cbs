/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Events.NotificationGateway.Reporting.SMS;
using Policies.Reporting.Notifications;

namespace Policies.Specs.Reporting.for_notifications.when_parsing_a_text_message_with_a_correctly_formated_single_case_report.separated_by_star.given
{
    public class a_text_message_received_builder_for_single_case_report_separated_by_star : Policies.Specs.Reporting.for_notifications.when_parsing_a_text_message_with_a_correctly_formated_single_case_report.
        given.a_text_message_received_builder_for_single_case_report
    {
        static readonly char separator = '*';
        protected static TextMessageReceived valid_text_message_received(bool woman, bool under5) => valid_text_message_received(woman, under5, separator);
        protected static TextMessageReceived text_message_received_with_invalid_health_risk_id(bool woman, bool under5) => text_message_received_with_invalid_health_risk_id(woman, under5, separator);
        protected static TextMessageReceived text_message_received_with_invalid_age_group(bool woman) => text_message_received_with_invalid_age_group(woman, separator);
        protected static TextMessageReceived text_message_received_with_invalid_sex(bool under5) => text_message_received_with_invalid_sex(under5, separator);
        protected static TextMessageReceived text_message_received_with_negative_health_risk_id(bool woman, bool under5) => text_message_received_with_negative_health_risk_id(woman, under5, separator);
        protected static TextMessageReceived text_message_received_with_negative_age_group(bool woman) => text_message_received_with_negative_age_group(woman, separator);
        protected static TextMessageReceived text_message_received_with_negative_sex(bool under5) => text_message_received_with_negative_sex(under5, separator);
        protected static TextMessageReceived text_message_received_with_out_of_range_age_group(bool woman) => text_message_received_with_out_of_range_age_group(woman, separator);
        protected static TextMessageReceived text_message_received_with_out_of_range_sex(bool under5) => text_message_received_with_out_of_range_age_group(under5, separator);
    }
}