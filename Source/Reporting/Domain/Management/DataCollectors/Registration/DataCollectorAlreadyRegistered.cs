/*---------------------------------------------------------------------------------------------
 *  Copyright (c) The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace Domain.Management.DataCollectors.Registration
{
    public class DataCollectorAlreadyRegistered : Exception
    {
        public DataCollectorAlreadyRegistered(string message) : base(message)
        {
        }
    }
}