/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Rules;

namespace Rules.DataCollectors
{
    public class RegionMustBeReal : IRuleImplementationFor<Domain.Management.DataCollectors.RegionMustBeReal>
    {
        public RegionMustBeReal() { }
        public Domain.Management.DataCollectors.RegionMustBeReal Rule => (location) => !location.Value.StartsWith("[");
    }
}