/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using System.IO;

namespace Infrastructure.AspNet.LocalizedStrings
{
    internal class UnparsedStringsProvider : IUnparsedStringsProvider
    {
        private readonly string _stringsResourcePath = Directory.GetCurrentDirectory() + @"\Localization\Strings";

        public IEnumerable<UnparsedLocalizedStrings> GetUnparsedLocalizedStrings()
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
                        yield return new UnparsedLocalizedStrings(locale, contents);
                    }

                }
            }
        }
    }

}
