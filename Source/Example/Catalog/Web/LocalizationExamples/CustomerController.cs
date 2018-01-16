/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Globalization;
using Infrastructure.AspNet.StringLocalization;
using Microsoft.AspNetCore.Mvc;
using Web.Localization.Customer;

namespace Web.LocalizationExamples
{
    [Route("LocalizationExamples/Customer")]
    public class CustomerExampleController : Controller
    {
        private readonly CustomerStrings _customerStrings;
        private readonly CustomerStrings _frenchStrings;

        public CustomerExampleController(ILocalizedStringsFactory<CustomerStrings> factory)
        {
            //Would normally get culture from current user
            var culture = CultureInfo.GetCultureInfo("en");
            _customerStrings = factory.GetLocalizedStringManager(culture);

            //Retrieve French strings, for demonstration purposes
            var frenchCulture = CultureInfo.GetCultureInfo("fr");
            _frenchStrings = factory.GetLocalizedStringManager(frenchCulture);
        }

        /// <summary>
        /// Example of localization usage
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public CustomerStrings Get(bool isFrenchUser)
        {
            return isFrenchUser ? _frenchStrings : _customerStrings;
        }
    }
}
