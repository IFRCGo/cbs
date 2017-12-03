/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Castle.DynamicProxy;

namespace Infrastructure.AspNet.LocalizedStrings
{
    internal class LocalizedStringsManagerFactory<T> : ILocalizedStringsManagerFactory<T>
            where T : class, new()
    {
        private readonly IEnumerable<LocalizedStringsProvider> _providers;

        public LocalizedStringsManagerFactory(IEnumerable<LocalizedStringsProvider> providers)
        {
            _providers = providers;
        }

        public T GetLocalizedStringManager(CultureInfo culture)
        {
            var provider = _providers.SingleOrDefault(p =>
                p.Locale.Equals(culture.TwoLetterISOLanguageName, StringComparison.InvariantCultureIgnoreCase));

            if (provider != null)
            {
                return new ProxyGenerator().CreateClassProxy<T>(
                    new OverwriteStringInterceptor(provider.LocalizedStrings));
            }
            return new T();
        }
    }
}
