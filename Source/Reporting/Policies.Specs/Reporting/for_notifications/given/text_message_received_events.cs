/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Events.NotificationGateway.Reporting.SMS;
using Policies.Reporting.Notifications;

namespace Policies.Specs.Reporting.for_notifications.given
{
    public class text_message_received_events
    {
        protected static TextMessageReceived empty_text_message_received()
        {
            return new TextMessageReceived(Guid.NewGuid(), "", "", DateTimeOffset.Now);
        }
        protected static TextMessageReceived text_message_received_with_text(string text)
        {
            return new TextMessageReceived(Guid.NewGuid(), "", text, DateTimeOffset.Now);
        }
    }
}