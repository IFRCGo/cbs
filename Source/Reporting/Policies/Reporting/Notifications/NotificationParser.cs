/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Events.NotificationGateway.Reporting.SMS;

namespace Policies.Reporting.Notifications
{
    public class NotificationParser : INotificationParser
    {
        private static readonly char[] Separators = { '#', '*' };

        /// <inheritdoc/>
        public NotificationParsingResult Parse(TextMessageReceived notification)
        {
            var content = notification.Text;

            var fragments = content.Replace(" ", string.Empty).Split(Separators).Select(s => new NotificationFragment(s));
            var result = new NotificationParsingResult(fragments);
            return result;
        }
    }
}