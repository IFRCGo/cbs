/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts.Users
{
    public class UserId : ConceptAs<Guid>
    {
        public static readonly UserId Empty = Guid.Empty;

        public static implicit operator UserId(Guid value)
        {
            return new UserId { Value = value };
        }
        public static implicit operator UserId(string value)
        {
            return new UserId { Value = Guid.Parse(value) };
        }
    }
}