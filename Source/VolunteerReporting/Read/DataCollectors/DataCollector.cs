/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Concepts;
using Dolittle.ReadModels;

namespace Read.DataCollectors
{
    public class DataCollector : IReadModel
    {
        public DataCollectorId Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public Location Location { get; set; }

        public string Region { get; set; }
        public string District { get; set; }
        public string Village { get; set; }

        public DataCollector(DataCollectorId id)
        {
            Id = id;
            Location = Location.NotSet;
        }
    }
}