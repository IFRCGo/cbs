/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy;

namespace Infrastructure.AspNet.StringLocalization
{
    internal class OverwriteStringInterceptor : IInterceptor
    {
        private readonly IDictionary<string, string> _localizedStrings;

        private const string GetterPrefix = "get_";

        public OverwriteStringInterceptor(IDictionary<string, string> localizedStrings)
        {
            _localizedStrings = localizedStrings;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            if (IsStringGetter(invocation.Method))
            {
                var propertyName = invocation.Method.Name.Replace(GetterPrefix, "");
                var success = _localizedStrings.TryGetValue(propertyName, out var result);
                if (success)
                {
                    invocation.ReturnValue = result;
                }
            }
        }

        private bool IsStringGetter(MethodInfo method)
        {
            return method.Name.StartsWith(GetterPrefix) && method.ReturnType == typeof(string);
        }
    }
}