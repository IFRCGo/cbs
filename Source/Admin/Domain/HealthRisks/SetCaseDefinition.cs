/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.HealthRisks;
using Dolittle.Commands;

namespace Domain.HealthRisks
{
    public class SetCaseDefinition : ICommand
    {
        public HealthRiskId HealthRisk { get; set; }
        public CaseDefinition CaseDefinition { get; set; }
    }
}