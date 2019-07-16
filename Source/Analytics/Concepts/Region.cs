/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts
{
    public class Region : ConceptAs<string>
    {
        public static implicit operator Region(string value)
        {
            return new Region {Value = value};
        }
    }
}
