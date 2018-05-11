/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Collections;
using Dolittle.Types;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization;
using Read.StaffUsers.Models;

namespace Web
{
    public class Startup : Infrastructure.AspNet.Startup
    {
        public Startup(
            ILoggerFactory loggerFactory,
            IHostingEnvironment env,
            IConfiguration configuration,
            IInstancesOf<BsonClassMap>maps) : base(loggerFactory, env, configuration)
        {
            RegisterAll(maps);
        }
        public void RegisterAll(IInstancesOf<BsonClassMap> maps)
        {
            maps.ForEach(BsonClassMap.RegisterClassMap);
        }
    }
}