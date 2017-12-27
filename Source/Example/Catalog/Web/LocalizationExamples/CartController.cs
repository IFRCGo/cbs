/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Globalization;
using Infrastructure.AspNet.StringLocalization;
using Microsoft.AspNetCore.Mvc;
using Web.Localization.Cart;

namespace Web.LocalizationExamples
{
    [Route("LocalizationExamples/Cart")]
    public class CartExampleController : Controller
    {
        private readonly CartStrings _cartStrings;
        private readonly CartStrings _frenchStrings;

        public CartExampleController(ILocalizedStringsFactory<CartStrings> factory)
        {
            //Would normally get culture from current user
            var culture = CultureInfo.GetCultureInfo("en");
            _cartStrings = factory.GetLocalizedStringManager(culture);

            //Retrieve French strings, for demonstration purposes
            var frenchCulture = CultureInfo.GetCultureInfo("fr");
            _frenchStrings = factory.GetLocalizedStringManager(frenchCulture);
        }

        /// <summary>
        /// Example of localization usage
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public CartStrings Get(bool isFrenchUser)
        {
            return isFrenchUser ? _frenchStrings : _cartStrings;
        }
    }
}
