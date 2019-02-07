/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts.DataCollector;
using Dolittle.ReadModels;

namespace Read.DataCollectors
{
    public class DataCollector : IReadModel
    { 
        public DataCollector(DataCollectorId id)
        {
            Id = id;
        }
        public DataCollectorId Id { get; set; }

        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }

        public string District { get; set; }
        public string Region { get; set; }
        public string Village { get; set; }

        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }
        public DateTimeOffset? LastReportRecievedAt { get; set; }

        /// Comment from woksin 13.09-18: The dictionary might or might not work with dolittles platform as of now. 
         public IDictionary<string, object> ExtraElements { get; set; } = new Dictionary<string, object>();

    }
}
