/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Events.NotificationGateway.Reporting.SMS;
using Policies.Reporting.Notifications;

namespace Policies.Specs.Reporting.for_notifications.when_parsing_a_text_message_with_a_correctly_formated_aggregated_case_report.given
{
    public class text_message_received_events_containing_aggregated_case_reports : Policies.Specs.Reporting.for_notifications.given.text_message_received_events
    {
        static char[] separators = new char[]{'#', '*'};
        static string get_text(string health_risk_value, string males_under_5, string males_over_5, string females_under_5, string females_over_5, char? separator) => 
            separator.HasValue? 
                $"{health_risk_value}{separator.Value}{males_under_5}{separator.Value}{males_over_5}{separator.Value}{females_under_5}{separator.Value}{females_over_5}" 
                : $"{health_risk_value}{separators[0]}{males_under_5}{separators[1]}{males_over_5}{separators[0]}{females_under_5}{separators[1]}{females_over_5}" ; 
        protected static readonly int valid_health_risk_id = 1;

        protected static readonly int negative_health_risk_id = -1;

        protected static readonly string invalid_health_risk_id = "SomeSickness";

        protected static readonly int valid_number = 1;
        protected static readonly string invalid_number_value = "under5";

        protected static readonly int negative_number = -1;

        protected static TextMessageReceived valid_text_message_received(int males_under_5, int males_over_5, int females_under_5, int females_over_5, char? separator)
        {
            var text = get_text(valid_health_risk_id.ToString(), males_under_5.ToString(), males_over_5.ToString(), females_under_5.ToString(), females_over_5.ToString(), separator);
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_invalid_health_risk_id(char? separator)
        {
            var text = get_text(invalid_health_risk_id, valid_number.ToString(), valid_number.ToString(), valid_number.ToString(), valid_number.ToString(), separator);
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_invalid_cases_of_male_under_5(char? separator) 
        {
            var text = get_text(valid_health_risk_id.ToString(), invalid_number_value, valid_number.ToString(), valid_number.ToString(), valid_number.ToString(), separator);
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_invalid_cases_of_male_over_5(char? separator) 
        {
            var text = get_text(valid_health_risk_id.ToString(), valid_number.ToString(), invalid_number_value, valid_number.ToString(), valid_number.ToString(), separator);

            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_invalid_cases_of_female_under_5(char? separator)
        {
            var text = get_text(valid_health_risk_id.ToString(), valid_number.ToString(), valid_number.ToString(), invalid_number_value, valid_number.ToString(), separator);
            
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_invalid_cases_of_female_over_5(char? separator) 
        {
            var text = get_text(valid_health_risk_id.ToString(), valid_number.ToString(), valid_number.ToString(), valid_number.ToString(), invalid_number_value, separator);
            
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_negative_health_risk_id(char? separator)
        {
            var text = get_text(negative_health_risk_id.ToString(), valid_number.ToString(), valid_number.ToString(), valid_number.ToString(), valid_number.ToString(), separator);
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_negative_cases_of_male_under_5(char? separator) 
        {
            var text = get_text(valid_health_risk_id.ToString(), negative_number.ToString(), valid_number.ToString(), valid_number.ToString(), valid_number.ToString(), separator);
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_negative_cases_of_male_over_5(char? separator) 
        {
            var text = get_text(valid_health_risk_id.ToString(), valid_number.ToString(), negative_number.ToString(), valid_number.ToString(), valid_number.ToString(), separator);

            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_negative_cases_of_female_under_5(char? separator)
        {
            var text = get_text(valid_health_risk_id.ToString(), valid_number.ToString(), valid_number.ToString(), negative_number.ToString(), valid_number.ToString(), separator);
            
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_negative_cases_of_female_over_5(char? separator) 
        {
            var text = get_text(valid_health_risk_id.ToString(), valid_number.ToString(), valid_number.ToString(), valid_number.ToString(), negative_number.ToString(), separator);
            
            return text_message_received_with_text(text);
        }
    }
}