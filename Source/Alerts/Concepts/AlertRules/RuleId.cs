/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts.AlertRules
{
    public class RuleId:ConceptAs<Guid>
    {
        public static readonly RuleId Empty = Guid.Empty;

        public static implicit operator RuleId(Guid value)
        {
            return new RuleId { Value = value };
        }
        public static implicit operator RuleId(string value)
        {
            return new RuleId { Value = Guid.Parse(value) };
        }
    }
}