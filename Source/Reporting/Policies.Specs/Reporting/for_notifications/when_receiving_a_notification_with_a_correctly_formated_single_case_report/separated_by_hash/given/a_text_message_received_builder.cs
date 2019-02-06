/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Events.NotificationGateway.Reporting.SMS;
using Policies.Reporting.Notifications;

namespace Policies.Specs.Reporting.for_notifications.when_receiving_a_notification_with_a_correctly_formated_single_case_report.separated_by_hash.given
{
    public class a_text_message_received_builder
    {
        protected static readonly int valid_health_risk_id = 1;

        protected static readonly int negative_health_risk_id = -1;

        protected static readonly string invalid_health_risk_id = "SomeSickness";

        protected static readonly string invalid_age_group = "under5";

        protected static readonly int out_of_range_age_group = 0;

        protected static readonly int negative_age_group = -1;

        protected static readonly string invalid_sex = "male";

        protected static readonly int out_of_range_sex = 0;

        protected static readonly int negative_sex = -1;

        protected static TextMessageReceived get_valid_text_message_received(bool woman, bool under5)
        {
            var sex_value = woman? "2" : "1";
            var age_value = under5? "1" : "2";

            return new TextMessageReceived(Guid.NewGuid(), "sender", $"{valid_health_risk_id}#{sex_value}#{age_value}", DateTimeOffset.Now);
        }
        protected static TextMessageReceived get_text_message_received_with_invalid_health_risk_id(bool woman, bool under5)
        {
            
            var sex_value = woman? "2" : "1";
            var age_value = under5? "1" : "2";
             
            return new TextMessageReceived(Guid.NewGuid(), "sender", $"{invalid_health_risk_id}#{sex_value}#{age_value}", DateTimeOffset.Now);
        }
        protected static TextMessageReceived get_text_message_received_with_invalid_age_group(bool woman) 
        {
            var sex_value = woman? "2" : "1";
             
            return new TextMessageReceived(Guid.NewGuid(), "sender", $"{valid_health_risk_id}#{sex_value}#{invalid_age_group}", DateTimeOffset.Now);
        }
        protected static TextMessageReceived get_text_message_received_with_invalid_sex(bool under5) 
        {
            var age_value = under5? "1" : "2";
             
            return new TextMessageReceived(Guid.NewGuid(), "sender", $"{valid_health_risk_id}#{invalid_sex}#{age_value}", DateTimeOffset.Now);
        }
        protected static TextMessageReceived get_text_message_received_with_negative_health_risk_id(bool woman, bool under5)
        {
            
            var sex_value = woman? "2" : "1";
            var age_value = under5? "1" : "2";
             
            return new TextMessageReceived(Guid.NewGuid(), "sender", $"{negative_health_risk_id}#{sex_value}#{age_value}", DateTimeOffset.Now);
        }
        protected static TextMessageReceived get_text_message_received_with_negative_age_group(bool woman) 
        {
            var sex_value = woman? "2" : "1";
             
            return new TextMessageReceived(Guid.NewGuid(), "sender", $"{valid_health_risk_id}#{sex_value}#{negative_age_group}", DateTimeOffset.Now);
        }
        protected static TextMessageReceived get_text_message_received_with_negative_sex(bool under5) 
        {
            var age_value = under5? "1" : "2";
             
            return new TextMessageReceived(Guid.NewGuid(), "sender", $"{valid_health_risk_id}#{negative_sex}#{age_value}", DateTimeOffset.Now);
        }
        protected static TextMessageReceived get_text_message_received_with_out_of_range_age_group(bool woman) 
        {
            var sex_value = woman? "2" : "1";
             
            return new TextMessageReceived(Guid.NewGuid(), "sender", $"{valid_health_risk_id}#{sex_value}#{negative_age_group}", DateTimeOffset.Now);
        }
        protected static TextMessageReceived get_text_message_received_with_out_of_range_sex(bool under5) 
        {
            var age_value = under5? "1" : "2";
             
            return new TextMessageReceived(Guid.NewGuid(), "sender", $"{valid_health_risk_id}#{negative_sex}#{age_value}", DateTimeOffset.Now);
        }
    }
}