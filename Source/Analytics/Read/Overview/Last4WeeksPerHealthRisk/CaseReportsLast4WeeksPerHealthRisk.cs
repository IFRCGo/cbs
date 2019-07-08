/*---------------------------------------------------------------------------------------------
*  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Concepts;
using Concepts.HealthRisks;
using Dolittle.ReadModels;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace Read.Overview.Last4WeeksPerHealthRisk
{
    public class CaseReportsLast4WeeksPerHealthRisk : IReadModel
    {
        public Day Id { get; set; }
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)]
        public IDictionary<HealthRiskId,CaseReportsLast4WeeksForHealthRisk> CaseReportsPerHelthRisk { get; set; }
    }
}
