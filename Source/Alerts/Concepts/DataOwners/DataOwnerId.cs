/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts.AlertRules
{
    public class DataOwnerId : ConceptAs<Guid>
    {
        public static readonly RuleId Empty = Guid.Empty;

        public static implicit operator DataOwnerId(Guid value)
        {
            return new DataOwnerId { Value = value };
        }
        public static implicit operator DataOwnerId(string value)
        {
            return new DataOwnerId { Value = Guid.Parse(value) };
        }
    }
}