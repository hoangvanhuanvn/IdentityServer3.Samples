﻿using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Thinktecture.IdentityServer.AccessTokenValidation;

[assembly: OwinStartup(typeof(Api.Startup))]

namespace Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:44319/identity",
                RequiredScopes = new[] { "sampleApi" }
            });

            // web api configuration
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);
        }
    }
}