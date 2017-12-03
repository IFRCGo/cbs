/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;

namespace Infrastructure.AspNet.LocalizedStrings
{
    internal class LocalizedStringsProvider
    {
        public LocalizedStringsProvider(string locale, IDictionary<string, string> localizedStrings)
        {
            Locale = locale;
            LocalizedStrings = localizedStrings;
        }

        public string Locale { get; }
        public IDictionary<string, string> LocalizedStrings { get; }
    }
}
