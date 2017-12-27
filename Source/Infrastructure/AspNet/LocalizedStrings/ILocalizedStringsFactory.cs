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
    /// <typeparam name="TFeatureStrings">
    /// Class with default string resources. Each feature must have a folder under ~/Localization with the name
    /// of the feature. The default strings must be placed in this folder with the name "[feature]Strings.cs".
    /// The strings must be declared as virtual properties with a default get value (no setters). Localized strings
    /// must be placed in this folder as json files with key-value pairs, where the key is the property name. The 
    /// name of the file must me the ISO 639-1 two-letter code for the locale.
    /// </typeparam>
    public interface ILocalizedStringsFactory<out TFeatureStrings>
        where TFeatureStrings : class, new()
    {
        /// <summary>
        /// Method for getting an instance of a string manager with localized strings.
        /// </summary>
        /// <param name="culture">Culture of the strings, retrieve these from the user settings.</param>
        /// <returns></returns>
        TFeatureStrings GetLocalizedStringManager(CultureInfo culture);
    }
}
