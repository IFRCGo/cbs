/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Applications;

namespace Infrastructure.AspNet
{
    public class Globals
    {
        public static BoundedContext BoundedContext { get; internal set; }
    }
}