/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Events.NotificationGateway.Reporting.SMS;
using Policies.Specs.Reporting.for_notifications.when_parsing_a_correctly_formated_aggregated_case_report_sms.given;

namespace Policies.Specs.Reporting.for_notifications.when_parsing_a_correctly_formated_aggregated_case_report_sms.separated_by_hash.given
{
    public class text_message_received_events_containing_aggregated_case_report : text_message_received_events_containing_aggregated_case_reports
    {
        static readonly char separator = '#';
        protected static TextMessageReceived valid_text_message_received(int males_under_5, int males_over_5, int females_under_5, int females_over_5 ) => valid_text_message_received(males_under_5, males_over_5, females_under_5, females_over_5, separator);
        protected static TextMessageReceived text_message_received_with_invalid_health_risk_id() => text_message_received_with_invalid_health_risk_id(separator);
        protected static TextMessageReceived text_message_received_with_invalid_cases_of_male_under_5() => text_message_received_with_invalid_cases_of_male_under_5(separator);
        protected static TextMessageReceived text_message_received_with_invalid_cases_of_male_over_5() => text_message_received_with_invalid_cases_of_male_over_5(separator);
        protected static TextMessageReceived text_message_received_with_invalid_cases_of_female_under_5() => text_message_received_with_invalid_cases_of_female_under_5(separator);
        protected static TextMessageReceived text_message_received_with_invalid_cases_of_female_over_5() => text_message_received_with_invalid_cases_of_female_over_5(separator);
        protected static TextMessageReceived text_message_received_with_negative_health_risk_id() => text_message_received_with_negative_health_risk_id(separator);
        protected static TextMessageReceived text_message_received_with_negative_cases_of_male_under_5() => text_message_received_with_negative_cases_of_male_under_5(separator);
        protected static TextMessageReceived text_message_received_with_negative_cases_of_male_over_5() => text_message_received_with_negative_cases_of_male_over_5(separator);
        protected static TextMessageReceived text_message_received_with_negative_cases_of_female_under_5() => text_message_received_with_negative_cases_of_female_under_5(separator);
        protected static TextMessageReceived text_message_received_with_negative_cases_of_female_over_5() => text_message_received_with_negative_cases_of_female_over_5(separator);
    }
}