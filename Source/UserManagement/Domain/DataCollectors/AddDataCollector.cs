/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Concepts;
using doLittle.Commands;

namespace Domain
{
    public class AddDataCollector : ICommand
    {
        //TODO: Update these properties to reflect what is needed for event. Remove PhoneNumber
        public Guid Id { get; set; }
        public string FirstName { get; set; } //Is FirstName / LastName robust enough for the areas that this will be used?  Shouldn't we just use name?
        public string LastName { get; set; }
        public int Age { get; set; }  //Shouldn't this be DOB so we can calculate the Age?
        public Sex Sex { get; set; } //Should we add Transgender?
        public Guid NationalSociety { get; set; }
        public Language PreferredLanguage { get; set; }
        public Location GpsLocation { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }
    }
}