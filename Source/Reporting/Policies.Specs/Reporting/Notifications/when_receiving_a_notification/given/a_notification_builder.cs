/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Policies.Reporting.Notifications;

namespace Policies.Specs.Reporting.Notifications.when_receiving_a_notification.given
{
    public class a_notification_builder
    {
        public static IEnumerable<NotificationFragment> get_valid_notification_aged_5_and_older()
        {
            return new List<NotificationFragment>
            {
                new NotificationFragment("1"), 
                new NotificationFragment("2"), 
                new NotificationFragment("2")
            };
        }
    }
}