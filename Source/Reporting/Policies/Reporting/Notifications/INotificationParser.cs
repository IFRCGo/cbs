/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Events.Admin.Reporting.HealthRisks;

namespace Policies.Reporting.Notifications
{
    public interface INotificationParser
    {
        NotificationParsingResult Parse(NotificationReceived notification);
    }
}