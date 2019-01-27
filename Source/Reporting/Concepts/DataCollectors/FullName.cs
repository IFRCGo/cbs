/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts.DataCollectors
{
    public class FullName : ConceptAs<string>
    {
        public static readonly FullName NotSet = String.Empty;

        public static implicit operator FullName(string id)
        {
            return new FullName { Value = id };
        }
    }
}