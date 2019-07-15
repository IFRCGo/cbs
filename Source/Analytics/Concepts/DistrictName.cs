/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts
{
    public class DistrictName : ConceptAs<string>
    {
        public static implicit operator DistrictName(string value)
        {
            return new DistrictName {Value = value};
        }
    }
}
