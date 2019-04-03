using System;
using System.IO;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Dolittle.DependencyInversion;
using Dolittle.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Core
{
    public class SecurityBindings : ICanProvideBindings
    {
        public void Provide(IBindingProviderBuilder builder)
        {
            builder.Bind<ClaimsPrincipal>().To(() =>
            {
                if (CurrentClaimsPrincipal.Value == null) return new ClaimsPrincipal(new ClaimsIdentity());
                return CurrentClaimsPrincipal.Value;
            });
            builder.Bind<ICanResolvePrincipal>().To(new PrincipalResolver());
        }

        internal static AsyncLocal<ClaimsPrincipal> CurrentClaimsPrincipal = new AsyncLocal<ClaimsPrincipal>();
        class PrincipalResolver : ICanResolvePrincipal
        {
            public ClaimsPrincipal Resolve()
            {
                if (CurrentClaimsPrincipal == null) return new ClaimsPrincipal(new ClaimsIdentity());
                return CurrentClaimsPrincipal.Value;
            }
        }
    }

    public static class SecurityExtensions
    {
        public static void AddSecurity(this IServiceCollection services, IHostingEnvironment env, PathString pathBase)
        {
            if (!env.IsDevelopment())
            {
                var authority = Environment.GetEnvironmentVariable("OPENID_AUTHORITY");
                var clientId = Environment.GetEnvironmentVariable("OPENID_CLIENT");

                services.AddAuthentication(options =>
                    {
                        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

                    })
                    .AddCookie((options) =>
                    {
                        options.Cookie.HttpOnly = false;
                        options.Cookie.SameSite = SameSiteMode.None;
                        options.DataProtectionProvider = DataProtectionProvider.Create(new DirectoryInfo(".cookies"));
                    })
                    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                    {
                        options.Authority = authority;
                        options.ClientId = clientId;
                        options.CallbackPath = pathBase + "/signin-oidc";
                        options.SignedOutCallbackPath = pathBase + "/signedout-oidc";
                        options.SignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.SignedOutRedirectUri = "https://cbsrc.org/";
                        options.UseTokenLifetime = true;
                        options.TokenValidationParameters = new TokenValidationParameters { NameClaimType = "name" };
                        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.Events.OnAuthorizationCodeReceived = async (context) =>
                        {
                            await Task.CompletedTask;
                        };

                        options.Events.OnRedirectToIdentityProvider = async (context) =>
                        {
                            context.ProtocolMessage.Scope = OpenIdConnectScope.OpenIdProfile;
                            context.ProtocolMessage.ResponseType = OpenIdConnectResponseType.IdToken;
                            if (!env.IsDevelopment())
                                context.ProtocolMessage.RedirectUri = context.ProtocolMessage.RedirectUri.Replace("http", "https");

                            await Task.CompletedTask;
                        };
                    });
            }
        }
        public static void UseSecurity(this IApplicationBuilder app, IHostingEnvironment env, PathString pathBase)
        {
            if (!env.IsDevelopment())
            {
                app.UseAuthentication();
                app.Use(async (httpContext, next) =>
                {
                    try
                    {
                        var authenticated = httpContext.User?.Identity?.IsAuthenticated ?? false;
                        if (!authenticated)
                        {
                            await httpContext.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties
                            {
                                RedirectUri = pathBase + "/"
                            });
                        }
                        else
                        {
                            // This is a workaround till Dolittle has moved over to the new approach for resolving principals
                            SecurityBindings.CurrentClaimsPrincipal.Value = httpContext.User;
                            await next();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception : " + ex.Message + " - " + ex.StackTrace);
                    }
                });
            }

            var routeBuilder = new RouteBuilder(app);
            var basePath = string.Empty;
            basePath = pathBase.Value.TrimStart('/');
            if (!basePath.EndsWith('/')) basePath = basePath + '/';

            routeBuilder.MapGet($"{basePath}signout", async (httpContext) =>
            {
                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await httpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
            });

            routeBuilder.MapGet($"{basePath}identity", async (httpContext) =>
            {
                var user = httpContext.User?.Identity?.Name ?? "[Not Logged In]";
                await httpContext.Response.WriteAsync(user);
            });
            var router = routeBuilder.Build();
            app.UseRouter(router);
        }
    }
}