/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Concepts.DataCollectors;
using Concepts.DataVerifiers;
using Dolittle.Commands;

namespace Domain.Management.DataCollectors.Registration
{
    public class RegisterDataCollector : ICommand
    {
        public DataCollectorId DataCollectorId { get; set; }
        public FullName FullName { get; set; }
        public DisplayName DisplayName { get; set; }
        public YearOfBirth YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location GpsLocation { get; set; }

        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }

        public Region Region { get; set; }
        public District District { get; set; }
        public DataVerifierId DataVerifierId { get; set; }
    }
}