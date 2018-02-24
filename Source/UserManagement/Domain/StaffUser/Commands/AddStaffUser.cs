/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts;
using doLittle.Commands;

namespace Domain
{
    public class AddStaffUser : ICommand
    {
        public Role Role { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public int YearOfBirth { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public string Position { get; set; }
        public string DutyStation { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }
        //public Location Area { get; set; } //TODO: I never understood Area
        //public string GeoLocation { get; set; }
        public string MobilePhoneNumber { get; set; }
        
        public Guid AssignedNationalSociety {get; set; }
    }
}
