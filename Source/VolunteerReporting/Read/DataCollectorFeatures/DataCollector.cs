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
        public Guid DataCollectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public string LocationLongitude { get; set; }
        public string LocationLatitude { get; set; }

        public DataCollector(Guid id)
        {
            DataCollectorId = id;
        }
    }
}