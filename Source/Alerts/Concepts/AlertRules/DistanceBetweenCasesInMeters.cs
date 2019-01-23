/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts.AlertRules
{
    public class DistanceBetweenCasesInMeters : ConceptAs<int>
    {
        public static implicit operator DistanceBetweenCasesInMeters(int value)
        {
            return new DistanceBetweenCasesInMeters { Value = value };
        }
    }
}