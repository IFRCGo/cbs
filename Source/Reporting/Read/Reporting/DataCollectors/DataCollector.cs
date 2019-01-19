/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts.DataCollectors;
using Dolittle.ReadModels;

namespace Read.Reporting.DataCollectors
{
    public class DataCollector : IReadModel
    { 
        public DataCollectorId Id { get; set; }

        public FullName FullName { get; set; }
        public DisplayName DisplayName { get; set; }
        public YearOfBirth YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }

        public District District { get; set; }
        public Region Region { get; set; }
        public Village Village { get; set; }

        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }
        public DateTimeOffset? LastReportReceivedAt { get; set; }
    }
}
