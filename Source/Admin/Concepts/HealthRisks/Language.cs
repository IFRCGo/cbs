/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts.HealthRisks
{
    public class Language : ConceptAs<string>
    {
        public static implicit operator Language(string language) => new Language { Value = language };
    }
}