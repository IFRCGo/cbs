/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Concepts;

namespace Concepts.HealthRisks
{
    public class CaseDefinition : ConceptAs<string>
    {
        public static implicit operator CaseDefinition(string caseDefinition) => new CaseDefinition { Value = caseDefinition };
    }
}