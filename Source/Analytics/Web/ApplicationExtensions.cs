using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders.Physical;

namespace Web
{
    public static class ApplicationExtensions
    {
        const string PathBase = "./wwwroot/";
        public static void ServeSinglePageApplication(this IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var path = $"{PathBase}/index.html";
                if (Path.HasExtension(context.Request.Path))
                {
                    path = $"{PathBase}/{context.Request.Path}";
                    
                }
                await context.Response.SendFileAsync(new PhysicalFileInfo(new FileInfo(path)));
                await Task.CompletedTask;
            });
        }
    }
}
