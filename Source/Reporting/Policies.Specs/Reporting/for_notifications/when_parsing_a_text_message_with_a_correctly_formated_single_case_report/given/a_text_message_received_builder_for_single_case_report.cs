/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Events.NotificationGateway.Reporting.SMS;
using Policies.Reporting.Notifications;

namespace Policies.Specs.Reporting.for_notifications.when_parsing_a_text_message_with_a_correctly_formated_single_case_report.given
{
    public class a_text_message_received_builder_for_single_case_report : Policies.Specs.Reporting.for_notifications.given.text_message_received_events
    {
        static char[] separators = new char[]{'#', '*'};

        static string get_sex_value (bool woman) => woman? "2" : "1";
        static string get_age_value (bool under5) => under5? "1" : "2";
        static string get_text(string sex_value, string age_value, string health_risk_value, char? separator) => 
            separator.HasValue? $"{health_risk_value}{separator.Value}{sex_value}{separator.Value}{age_value}" : $"{health_risk_value}{separators[0]}{sex_value}{separators[1]}{age_value}"; 
        protected static readonly int valid_health_risk_id = 1;

        protected static readonly int negative_health_risk_id = -1;

        protected static readonly string invalid_health_risk_id = "SomeSickness";

        protected static readonly string invalid_age_group = "under5";

        protected static readonly int out_of_range_age_group = 0;

        protected static readonly int negative_age_group = -1;

        protected static readonly string invalid_sex = "male";

        protected static readonly int out_of_range_sex = 0;

        protected static readonly int negative_sex = -1;

        protected static TextMessageReceived valid_text_message_received(bool woman, bool under5, char? separator)
        {
            var sex_value = get_sex_value(woman);
            var age_value = get_age_value(under5);
            var text = get_text(sex_value, age_value, valid_health_risk_id.ToString(), separator);
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_invalid_health_risk_id(bool woman, bool under5, char? separator)
        {
            var sex_value = get_sex_value(woman);
            var age_value = get_age_value(under5);
            var text = get_text(sex_value, age_value, invalid_health_risk_id, separator);
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_invalid_age_group(bool woman, char? separator) 
        {
            var sex_value = get_sex_value(woman);
            var text = get_text(sex_value, invalid_age_group, valid_health_risk_id.ToString(), separator);
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_invalid_sex(bool under5, char? separator) 
        {
            var age_value = get_age_value(under5);
            var text = get_text(invalid_sex, age_value, valid_health_risk_id.ToString(), separator);

            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_negative_health_risk_id(bool woman, bool under5, char? separator)
        {
            var sex_value = get_sex_value(woman);
            var age_value = get_age_value(under5);
            var text = get_text(sex_value, age_value, negative_health_risk_id.ToString(), separator);
            
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_negative_age_group(bool woman, char? separator) 
        {
            var sex_value = get_sex_value(woman);
            var text = get_text(sex_value, negative_age_group.ToString(), valid_health_risk_id.ToString(), separator);
            
            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_negative_sex(bool under5, char? separator) 
        {
            var age_value = get_age_value(under5);
            var text = get_text(negative_sex.ToString(), age_value, valid_health_risk_id.ToString(), separator);

            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_out_of_range_age_group(bool woman, char? separator) 
        {
            var sex_value = get_sex_value(woman);
            var text = get_text(sex_value, out_of_range_age_group.ToString(), valid_health_risk_id.ToString(), separator);

            return text_message_received_with_text(text);
        }
        protected static TextMessageReceived text_message_received_with_out_of_range_sex(bool under5, char? separator) 
        {
            var age_value = get_age_value(under5);
            var text = get_text(out_of_range_sex.ToString(), age_value, valid_health_risk_id.ToString(), separator);

            return text_message_received_with_text(text);
        }
    }
}