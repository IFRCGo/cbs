// /*---------------------------------------------------------------------------------------------
//  *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
//  *  Licensed under the MIT License. See LICENSE in the project root for license information.
//  *--------------------------------------------------------------------------------------------*/

using Infrastructure.AspNet;

namespace Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return Initialization.BuildAndRun<Startup>("Catalog", args);
        }
    }
}