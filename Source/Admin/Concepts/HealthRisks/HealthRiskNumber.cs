/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts.HealthRisks
{
    public class HealthRiskNumber : ConceptAs<int>
    {
        public static implicit operator HealthRiskNumber(int number) => new HealthRiskNumber { Value = number };
        public static implicit operator HealthRiskNumber(string number) => new HealthRiskNumber { Value = int.Parse(number) };

    }
}