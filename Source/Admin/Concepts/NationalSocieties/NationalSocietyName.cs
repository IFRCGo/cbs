/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts.NationalSocieties
{
    public class NationalSocietyName : ConceptAs<string>
    {
        public static readonly NationalSocietyName Empty = string.Empty;

        public static implicit operator NationalSocietyName(string value)
        {
            return new NationalSocietyName { Value = value };
        }
    }
}