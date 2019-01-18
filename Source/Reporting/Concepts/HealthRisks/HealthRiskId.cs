/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;
using System;

namespace Concepts.HealthRisks
{
    public class HealthRiskId : ConceptAs<Guid>
    {
        public static readonly HealthRiskId NotSet = Guid.Empty;

        public static implicit operator HealthRiskId(Guid id)
        {
            return new HealthRiskId { Value = id };
        }
        public static implicit operator HealthRiskId(string id)
        {
            return new HealthRiskId { Value = Guid.Parse(id) };
        }
    }
}
