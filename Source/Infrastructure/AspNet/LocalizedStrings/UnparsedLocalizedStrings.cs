/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Infrastructure.AspNet.LocalizedStrings
{
    internal class UnparsedLocalizedStrings
    {
        public UnparsedLocalizedStrings(string locale, string json)
        {
            Locale = locale;
            StringsJson = json;
        }
        public string Locale { get; set; }
        public string StringsJson { get; set; }
    }
}
