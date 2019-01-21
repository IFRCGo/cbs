/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts.HealthRisks
{
    public class HealthRiskReadableId : ConceptAs<int>
    {
        
        public static readonly HealthRiskReadableId NotSet = -1;

        public static implicit operator HealthRiskReadableId(int id)
        {
            return new HealthRiskReadableId { Value = id };
        }

        public static implicit operator HealthRiskReadableId(string id)
        {
            return new HealthRiskReadableId { Value = int.Parse(id) };
        }

    }
}
