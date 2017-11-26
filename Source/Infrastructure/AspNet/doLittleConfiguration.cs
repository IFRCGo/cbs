using doLittle.Events.Processing;
using doLittle.Runtime.Events.Coordination;
using doLittle.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.AspNetCore.Builder
{
    public static class doLittleConfiguration
    {

        public static IApplicationBuilder UsedoLittle(this IApplicationBuilder app, IHostingEnvironment env)
        {
            var committedEventStreamCoordinator = app.ApplicationServices.GetService(typeof(ICommittedEventStreamCoordinator)) as ICommittedEventStreamCoordinator;
            committedEventStreamCoordinator.Initialize();

            return app;
        }
    }
}