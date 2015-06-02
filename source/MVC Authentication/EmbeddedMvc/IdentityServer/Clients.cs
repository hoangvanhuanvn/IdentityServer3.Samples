﻿using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace EmbeddedMvc.IdentityServer
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client 
                {
                    Enabled = true,
                    ClientName = "MVC Client",
                    ClientId = "mvc",
                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        "http://localhost:44319/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:44319/"
                    }
                },
                new Client
                {
                    Enabled = true,
                    ClientName = "MVC Client (service communication)",
                    
                    ClientId = "mvc_service",
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret("secret".Sha256())
                    },
                    
                    Flow = Flows.ClientCredentials
                }
            };
        }
    }
}