/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Globalization;
using Infrastructure.AspNet.LocalizedStrings;
using Microsoft.AspNetCore.Mvc;
using Web.Localization;

namespace Web
{
    [Route("StringLocalizationExample")]
    public class StringLocalizationExampleController : Controller
    {
        private readonly ILocalizedStringsManagerFactory<ExampleStringManager> _factory;

        public StringLocalizationExampleController(ILocalizedStringsManagerFactory<ExampleStringManager> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Example of localization usage
        /// </summary>
        /// <param name="culture">Valid two-letter localization. Example values: "en", "fr", "fi"</param>
        /// <returns></returns>
        [HttpGet]
        public ExampleStringManager Get(string culture)
        {
            // The culture will normally be retrieved from user info
            var locale = CultureInfo.GetCultureInfo(culture);
            return _factory.GetLocalizedStringManager(locale);
        }

    }
}
