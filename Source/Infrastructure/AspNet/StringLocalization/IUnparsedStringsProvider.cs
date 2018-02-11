/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;

namespace Infrastructure.AspNet.StringLocalization
{
    internal interface IUnparsedStringsProvider
    {
        IEnumerable<UnparsedLocalizedStrings> GetUnparsedLocalizedStrings();
    }
}