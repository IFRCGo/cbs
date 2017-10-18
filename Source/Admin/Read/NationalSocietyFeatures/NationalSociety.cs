/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Read.NationalSocietyFeatures
{
    public class NationalSociety
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
        public string Country { get; set; }
    }
}