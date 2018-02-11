/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using doLittle.Runtime.Events.Coordination;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.AspNetCore.Builder
{
    public static class doLittleConfiguration
    {
        public static IApplicationBuilder UsedoLittle(this IApplicationBuilder app, IHostingEnvironment env)
        {
            var committedEventStreamCoordinator =
                app.ApplicationServices.GetService(typeof(ICommittedEventStreamCoordinator)) as
                    ICommittedEventStreamCoordinator;
            committedEventStreamCoordinator.Initialize();

            return app;
        }
    }
}