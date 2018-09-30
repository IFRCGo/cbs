/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
 
using System.Collections.Generic;
using Concepts;
using Concepts.DataCollector;
using Dolittle.Commands;

namespace Domain.DataCollectors.Registering
{
    public class RegisterDataCollector : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }

        public string FullName { get; set; }
        public string DisplayName { get; set; }
        //TODO: Add later on. public string Email { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location GpsLocation { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }

        public string Region { get; set; }
        public string District { get; set; }
    }
}
