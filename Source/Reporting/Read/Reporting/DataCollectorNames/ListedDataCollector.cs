/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.DataCollectors;
using Dolittle.ReadModels;

namespace Read.Reporting.DataCollectorNames
{    public class ListedDataCollector : IReadModel
    { 
        public ListedDataCollector(DataCollectorId id)
        {
            Id = id;
        }
        public DataCollectorId Id { get; set; }

        public DisplayName DisplayName { get; set; }
        
        public Location Location { get; set; }

        public District District { get; set; }
        public Region Region { get; set; }
        public Village Village { get; set; }
    }
}