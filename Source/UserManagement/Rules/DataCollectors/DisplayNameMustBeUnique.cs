/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Linq;
using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.DataCollectors;

namespace Rules.DataCollectors
{
    public class DisplayNameMustBeUnique : IRuleImplementationFor<Domain.DataCollectors.DisplayNameMustBeUnique>
    {
        readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;
        public DisplayNameMustBeUnique(IReadModelRepositoryFor<DataCollector> dataCollectors) => _dataCollectors = dataCollectors;
        public Domain.DataCollectors.DisplayNameMustBeUnique Rule => (displayName) => !_dataCollectors.Query.Any(d => d.DisplayName == displayName);
    }
}