/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infrastructure.AspNet.LocalizedStrings
{
    internal class LocalizedStringsParser : ILocalizedStringsParser
    {

        public LocalizedStringsProvider ParseStrings(UnparsedLocalizedStrings strings)
        {
            var parsedStrings = JsonConvert.DeserializeObject<IDictionary<string, string>>(strings.StringsJson);
            return new LocalizedStringsProvider(strings.Locale, parsedStrings);
        }
    }
}
