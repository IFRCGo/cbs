/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts.NationalSocieties
{
    public class NationalSocietyId : ConceptAs<Guid>
    {
        public static readonly NationalSocietyId Empty = Guid.Empty;

        public static implicit operator NationalSocietyId(Guid value)
        {
            return new NationalSocietyId { Value = value };
        }
        public static implicit operator NationalSocietyId(string value)
        {
            return new NationalSocietyId { Value = Guid.Parse(value) };
        }
    }
}