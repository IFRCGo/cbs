/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts.NationalSocieties;
using Dolittle.Commands;

namespace Domain.NationalSocieties
{
    public class CreateNationalSociety : ICommand
    {
        public NationalSocietyId Id { get; set; }
        public NationalSocietyName Name { get; set; }
        public string Country { get; set; }
        public int TimezoneOffsetFromUtcInMinutes { get; set; }

    }
}
