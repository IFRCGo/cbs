/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Serilog;

namespace Infrastructure.AspNet.LocalizedStrings
{
    internal class LocalizedStringsParser : ILocalizedStringsParser
    {
        private readonly string _stringsResourcePath = Directory.GetCurrentDirectory() + @"\Localization\Strings";

        public IEnumerable<LocalizedStringsProvider> GetAllProviders()
        {
            var directoryInfo = new DirectoryInfo(_stringsResourcePath);
            if (Directory.Exists(_stringsResourcePath))
            {
                foreach (var file in directoryInfo.EnumerateFiles("*.json"))
                {
                    var locale = file.Name.Replace(file.Extension, "");
                    using (var fs = file.OpenText())
                    {
                        var contents = fs.ReadToEnd();
                        var strings = JsonConvert.DeserializeObject<Dictionary<string, string>>(contents);
                        yield return new LocalizedStringsProvider(locale, strings);
                    }

                }
            }
        }
    }
}
