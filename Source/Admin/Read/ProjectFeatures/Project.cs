/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.ReadModels;
using Events;
using Events.Project;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Read.NationalSocietyFeatures;
using Read.UserFeatures;

namespace Read.ProjectFeatures
{
    public class Project : IReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public User DataOwner { get; set; }
        public NationalSociety NationalSociety { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProjectSurveillanceContext SurveillanceContext { get; set; }

        public ProjectHealthRisk[] HealthRisks { get; set; }

        public User[] DataVerifiers { get; set; }

        public string SmsProxy { get; set; }
    }

    public class ProjectClassMap : MongoDbClassMap<Project>
    {
        public override void Map(BsonClassMap<Project> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(p => p.Id);
        }
    }
}