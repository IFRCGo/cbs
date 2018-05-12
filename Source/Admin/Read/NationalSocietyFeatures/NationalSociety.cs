/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.NationalSocietyFeatures
{
    public class NationalSociety : IReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int TimezoneOffsetFromUtcInMinutes { get; set; }
    }

    public class NatinalSocietyClassMap : MongoDbClassMap<NationalSociety>
    {
        public override void Map(BsonClassMap<NationalSociety> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(n => n.Id);
        }

        public override void Register()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(NationalSociety)))
                BsonClassMap.RegisterClassMap<NationalSociety>(Map);
        }
    }
}