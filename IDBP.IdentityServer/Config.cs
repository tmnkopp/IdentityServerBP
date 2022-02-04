using IdentityServer4.Models;
using System.Collections.Generic;

namespace IDBP.IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> ApiResources() 
        {
            return new List<ApiResource>
            {
                new ApiResource("IDBP_API"){
                    Scopes = new List<string> { "IDBP_API" },
                    ApiSecrets = new List<Secret> {  new Secret("secret".Sha256()) }
                }
            };
        }
        public static IEnumerable<ApiScope> ApiScopes()
        {
            return new List<ApiScope> {
                new ApiScope("IDBP_API")
             };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> {
                new Client()
                {
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets={ new Secret("secret".Sha256())  },
                    AllowedScopes={ "IDBP_API" }
                }
            };
        }
    }
}