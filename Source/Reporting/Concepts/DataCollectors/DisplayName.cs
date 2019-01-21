/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts.DataCollectors
{
    public class DisplayName : ConceptAs<string>
    {
        public static readonly DisplayName NotSet = String.Empty;

        public static implicit operator DisplayName(string id)
        {
            return new DisplayName { Value = id };
        }
    }
}