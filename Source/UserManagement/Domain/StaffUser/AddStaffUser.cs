/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using Concepts;

namespace Domain
{
    public class AddStaffUser
    {
        public Role Role { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public String Position { get; set; }
        public String DutyStation { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location Location { get; set; }
        public string MobilePhoneNumber { get; set; }
        public List<Guid> AssignedNationalSociety {get; set; }
    }
}
