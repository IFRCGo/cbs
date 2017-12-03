/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Globalization;

namespace Infrastructure.AspNet.LocalizedStrings
{
    /// <summary>
    /// Factory for generating string manager proxies. See Example project for a demonstration of usage.
    /// </summary>
    /// <typeparam name="T">
    /// Class with default string resources. Strings should be declared as virtual properties with a get value.
    /// Other localizations should be stored as key-value pairs where the key is the property name.
    /// Store these as json files under ~/Localization/Strings and use the ISO 639-1 two-letter code for the file name.
    /// </typeparam>
    public interface ILocalizedStringsManagerFactory<out T>
        where T : class, new()
    {
        /// <summary>
        /// Method for getting an instance of a string manager with localized strings.
        /// </summary>
        /// <param name="culture">Culture of the strings, retrieve these from the user settings</param>
        /// <returns></returns>
        T GetLocalizedStringManager(CultureInfo culture);
    }
}
