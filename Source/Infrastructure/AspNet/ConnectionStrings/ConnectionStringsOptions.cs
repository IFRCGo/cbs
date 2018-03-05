/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Infrastructure.AspNet.ConnectionStrings
{
    public class ConnectionStringsOptions
    {
        public ConnectionString[] ConnectionStrings { get; set; } = new ConnectionString[0];
    }
}