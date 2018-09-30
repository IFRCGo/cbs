/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Autofac.Core;
using Dolittle.DependencyInversion.Autofac;
using Infrastructure.AspNet.StringLocalization;
using Infrastructure.Rules;

namespace Infrastructure.AspNet
{
    public class RegistrationSourceProvider : ICanProvideRegistrationSources
    {
        public IEnumerable<IRegistrationSource> Provide()
        {
            return new IRegistrationSource[] {
                new MongoDB.MongoDBRegistrationSource(),
                new MongoDB.ReadModelRepositoryDBRegistrationSource(),
                new RuleRegistrationSource(), 
                new LocalizedStringsRegistrationsSource(new LocalizedStringsParser(),new UnparsedStringsProvider())
            };
        }
    }
}