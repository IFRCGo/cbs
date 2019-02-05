/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Policies.Reporting.Notifications
{
    public class NotificationFragment
    {
        public NotificationFragment(string value)
        {
            Value = value;

            Number = int.TryParse(value, out var tmp) ? tmp : default(int?);
        }

        public string Value { get; }

        public int? Number { get; }

        public bool HasValue =>
            Value != null && !Value.Equals(string.Empty);

        public bool IsValid =>
            HasValue && Number.HasValue;
    }
}