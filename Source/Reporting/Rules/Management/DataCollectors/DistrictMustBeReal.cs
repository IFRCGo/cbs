/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Rules;

namespace Rules.DataCollectors
{
    public class DistrictMustBeReal : IRuleImplementationFor<Domain.Management.DataCollectors.DistrictMustBeReal>
    {
        public DistrictMustBeReal() { }
        public Domain.Management.DataCollectors.DistrictMustBeReal Rule => (location) => !location.Value.StartsWith("[");
    }
}