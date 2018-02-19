/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace Domain
{
    public class UpdateReplyMessagesConfig
    {
        private IDictionary<string, IDictionary<string, string>> _messages;
        public static Guid Id => new Guid("660103E1-F434-465F-9FF8-14C9942B0E3C");

        public IDictionary<string, IDictionary<string, string>> Messages
        {
            get => _messages;
            set
            {
                _messages = new Dictionary<string, IDictionary<string, string>>(StringComparer.CurrentCultureIgnoreCase);
                foreach (var keyValuePair in value)
                {
                    var trimmedKey = keyValuePair.Key.Trim();
                    if (_messages.ContainsKey(trimmedKey))
                        throw new DuplicateTagException(trimmedKey);
                    _messages.Add(trimmedKey, keyValuePair.Value);
                }
            }
        }
    }

    public class DuplicateTagException : Exception
    {
        public DuplicateTagException(string trimdKey) : base("The tag is not unique: " + trimdKey)
        {

        }
    }
}