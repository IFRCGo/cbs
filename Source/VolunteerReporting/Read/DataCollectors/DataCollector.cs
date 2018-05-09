/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Concepts;
using Dolittle.ReadModels;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Read.DataCollectors
{
    public class DataCollector : IReadModel
    {
        public Guid DataCollectorId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public Location Location { get; set; }

        public string Region { get; set; }
        public string District { get; set; }
        public string Village { get; set; }

        public DataCollector(Guid dataCollectorId)
        {
            DataCollectorId = dataCollectorId;
            Location = Location.NotSet;
        }
    }

    public static class DataCollectorBsonClassMapRegistrator
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<DataCollector>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(r => r.DataCollectorId);
            });
        }
    }
}