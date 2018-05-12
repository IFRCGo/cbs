/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.UserFeatures
{
    public class User : IReadModel
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Country { get; set; }
        public Guid NationalSocietyId { get; set; }
    }

    public class UserClassMap : MongoDbClassMap<User>
    {
        public override void Map(BsonClassMap<User> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(u => u.Id);
        }

        public override void Register()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(User)))
                BsonClassMap.RegisterClassMap<User>(Map);
        }
    }
}