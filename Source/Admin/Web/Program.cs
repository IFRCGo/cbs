/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Infrastructure.AspNet;

namespace Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return Initialization.BuildAndRun<Startup>("Admin", args);
        }
    }
}