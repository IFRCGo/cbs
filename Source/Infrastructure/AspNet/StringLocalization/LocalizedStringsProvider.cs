/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;

namespace Infrastructure.AspNet.StringLocalization
{
    internal class LocalizedStringsProvider
    {
        public LocalizedStringsProvider(string locale, string name, IDictionary<string, string> localizedStrings)
        {
            Locale = locale;
            Name = name;
            LocalizedStrings = localizedStrings;
        }

        public string Locale { get; }
        public string Name { get; set; }
        public IDictionary<string, string> LocalizedStrings { get; }
    }
}