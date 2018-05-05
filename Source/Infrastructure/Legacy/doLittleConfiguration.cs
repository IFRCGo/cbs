/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Runtime.Events.Coordination;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.AspNetCore.Builder
{
    public static class DolittleConfiguration
    {
        public static IApplicationBuilder UseDolittle(this IApplicationBuilder app, IHostingEnvironment env)
        {
            var committedEventStreamCoordinator =
                app.ApplicationServices.GetService(typeof(ICommittedEventStreamCoordinator)) as
                    ICommittedEventStreamCoordinator;
            committedEventStreamCoordinator.Initialize();

            return app;
        }
    }
}