/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Concepts;

namespace Domain
{
    public class AddStaffUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public string Location { get; set; } //TODO: fix when location strucutre is known
        //public GeoCoordinate GeoLocation { get; set; } //TODO: use GeoCoordinate
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
