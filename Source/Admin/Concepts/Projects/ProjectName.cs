/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts.Projects
{
    public class ProjectName : ConceptAs<string>
    {
        public static readonly ProjectName Empty = string.Empty;

        public static implicit operator ProjectName(string value)
        {
            return new ProjectName { Value = value };
        }
    }
}