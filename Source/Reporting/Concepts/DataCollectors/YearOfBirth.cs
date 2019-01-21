/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts.DataCollectors
{
    public class YearOfBirth : ConceptAs<int>
    {
        public static readonly YearOfBirth NotSet = 0;

        public static implicit operator YearOfBirth(int value)
        {
            return new YearOfBirth { Value = value };
        }
    }
}