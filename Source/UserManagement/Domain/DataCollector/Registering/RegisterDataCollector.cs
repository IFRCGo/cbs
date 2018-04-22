/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts;
using Dolittle.Commands;

namespace Domain.DataCollector.Registering
{
    public class RegisterDataCollector : ICommand
    {
        public Guid DataCollectorId { get; set; }

        
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location GpsLocation { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }
        
        // Todo: we can deduct this from the command handler
        public DateTimeOffset RegisteredAt { get; set; }

        // Todo: This is wrong - the fact that it is a Register command means it is New by definition; implicitly
        public bool IsNewRegistration { get; set; }
    }
}
