/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Infrastructure.AspNet.ConnectionStrings
{
    public class ConnectionString
    {
        public ConnectionStringType Type { get; set; }
        public string Value { get; set; }
        public string Database { get; set; }
    }
}