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
    public class ListedDataCollector : IReadModel
    { 
        public ListedDataCollector(DataCollectorId id)
        {
            Id = id;
        }
        public DataCollectorId Id { get; set; }

        public string DisplayName { get; set; }
        
        public Location Location { get; set; }

        public string District { get; set; }
        public string Region { get; set; }
        public string Village { get; set; }
    }
}
