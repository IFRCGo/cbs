/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Rules;

namespace Rules.DataCollectors
{
    public class VillageMustBeReal : IRuleImplementationFor<Domain.Management.DataCollectors.VillageMustBeReal>
    {
        public VillageMustBeReal() { }
        public Domain.Management.DataCollectors.VillageMustBeReal Rule => (location) => !location.Value.StartsWith("[");
    }
}