/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Concepts;
using Concepts.DataCollectors;
using Dolittle.ReadModels;

namespace Read.DataCollectors
{
    public class DataCollector : IReadModel
    { 
        public DataCollectorId Id { get; set; }
        public string DisplayName { get; set; }
        public Location Location { get; set; }
        public string District { get; set; }
        public string Region { get; set; }
        public string Village { get; set; }
    }
}
