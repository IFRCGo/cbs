/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.DataCollectors;

namespace Rules.DataCollectors
{
    public class CantExist : IRuleImplementationFor<Domain.DataCollectors.CantExist>
    {
        readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;
        public CantExist(IReadModelRepositoryFor<DataCollector> dataCollectors) => _dataCollectors = dataCollectors;
        public Domain.DataCollectors.CantExist Rule => (dataCollector) => _dataCollectors.GetById(dataCollector) == null;
    }
}