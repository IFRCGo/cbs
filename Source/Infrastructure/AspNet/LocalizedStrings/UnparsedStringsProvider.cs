/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Infrastructure.AspNet.LocalizedStrings
{
    internal class UnparsedStringsProvider : IUnparsedStringsProvider
    {
        private readonly string _stringsResourcePath = Directory.GetCurrentDirectory() + @"\Localization";

        public IEnumerable<UnparsedLocalizedStrings> GetUnparsedLocalizedStrings()
        {
            var res = new List<UnparsedLocalizedStrings>();
            if (!Directory.Exists(_stringsResourcePath))
            {
                return res;
            }

            var directoryInfo = new DirectoryInfo(_stringsResourcePath);
            foreach (var featureDirectory in directoryInfo.EnumerateDirectories())
            {
                res.AddRange(GetFeatureStrings(featureDirectory));
            }
            return res;
        }

        private IEnumerable<UnparsedLocalizedStrings> GetFeatureStrings(DirectoryInfo featureDirectory)
        {
            var name = featureDirectory.Name;
            foreach (var file in featureDirectory.EnumerateFiles("*.json"))
            {
                var locale = file.Name.Replace(file.Extension, "");
                using (var fs = file.OpenText())
                {
                    var content = fs.ReadToEnd();
                    yield return new UnparsedLocalizedStrings(locale, name, content);
                }
            }
        }
    }
}
