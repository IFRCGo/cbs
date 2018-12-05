/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Concepts.HealthRisks;
using Dolittle.ReadModels;

namespace Read.HealthRisks
{
    public class HealthRisk : IReadModel
    {
        public HealthRiskId Id { get; set; }
        public HealthRiskNumber HealthRiskNumber { get; set; }
        public HealthRiskName Name { get; set; }
        public CaseDefinition CaseDefinition { get; set; }
        public IEnumerable<KeyMessage> KeyMessages { get; set; }
    }    
}