/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using System.Reflection;
using Dolittle.Collections;
using Dolittle.ReadModels;
using Dolittle.Types;
using Infrastructure.Read;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization;
using Read;
using Read.StaffUsers.Models;

namespace Web
{
    public class Startup : Infrastructure.AspNet.Startup
    {
        public Startup(
            ILoggerFactory loggerFactory,
            IHostingEnvironment env,
            IConfiguration configuration) : base(loggerFactory, env, configuration)
        {
            ReadModule.RegisterReadModelClassMaps();
        }
        
    }
}