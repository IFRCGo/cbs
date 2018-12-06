/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.ReadModels;

namespace Read.NationalSocieties
{
    public class NationalSociety : IReadModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public int TimezoneOffsetFromUtcInMinutes { get; set; }
    }
}