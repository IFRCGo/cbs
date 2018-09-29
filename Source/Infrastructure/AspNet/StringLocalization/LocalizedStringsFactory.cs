/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Castle.DynamicProxy;

namespace Infrastructure.AspNet.StringLocalization
{
    internal class LocalizedStringsFactory<T> : ILocalizedStringsFactory<T>
        where T : class, new()
    {
        private readonly IEnumerable<LocalizedStringsProvider> _providers;
        private readonly string _featureName;

        public LocalizedStringsFactory(IEnumerable<LocalizedStringsProvider> providers)
        {
            _providers = providers;
            _featureName = typeof(T).Name.ToLower().Replace("strings", "");
        }

        public T GetLocalizedStringManager(CultureInfo culture)
        {
            var provider = _providers.SingleOrDefault(p =>
                p.Locale.Equals(culture.TwoLetterISOLanguageName, StringComparison.InvariantCultureIgnoreCase) &&
                p.Name.Equals(_featureName, StringComparison.InvariantCultureIgnoreCase));

            if (provider != null)
            {
                return new ProxyGenerator().CreateClassProxy<T>(
                    new OverwriteStringInterceptor(provider.LocalizedStrings));
            }

            return new T();
        }
    }
}