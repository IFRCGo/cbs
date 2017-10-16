/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace Read
{
    public class DataCollector
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }

        public DataCollector(Guid id)
        {
            Id = id;
        }
    }
}