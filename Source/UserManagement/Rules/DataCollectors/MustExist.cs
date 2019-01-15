/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.DataCollectors;

namespace Rules.DataCollectors
{
    public class MustExist : IRuleImplementationFor<Domain.DataCollectors.MustExist>
    {
        readonly IReadModelRepositoryFor<DataCollector> _dataCollectors;
        public MustExist(IReadModelRepositoryFor<DataCollector> dataCollectors) => _dataCollectors = dataCollectors;
        public Domain.DataCollectors.MustExist Rule => (dataCollector) => _dataCollectors.GetById(dataCollector) != null;
    }
}