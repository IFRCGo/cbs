/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Concepts;
using Events.External;

namespace Policy.Notifications
{
    public class NotificationParser : INotificationParser
    {
        private static readonly char[] Separators = { '#', '*' };

        /// <inheritdoc/>
        public NotificationParsingResult Parse(NotificationReceived notification)
        {
            var content = notification.Message;

            var fragments = content.Replace(" ", string.Empty).Split(Separators).Select(s => new NotificationFragment(s));
            var result = new NotificationParsingResult(fragments);
            return result;
        }
    }
}