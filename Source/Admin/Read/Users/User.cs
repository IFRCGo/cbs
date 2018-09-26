/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.ReadModels;

namespace Read.Users
{
    public class User : IReadModel
    {
        public Guid Id { get; set; }

        //TODO: Change to FullName
        public string Firstname { get; set; }

        //TODO:Change to DisplayName 
        public string Lastname { get; set; }

        public string Country { get; set; }
        public Guid NationalSocietyId { get; set; }
    }
}