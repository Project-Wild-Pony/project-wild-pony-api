using Microsoft.AspNetCore.Authorization;

namespace Project.Wild.Pony.Api.Security
{
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Scope { get; }

        public HasScopeRequirement(string scope, string issuer)
        {
            Scope = scope ?? throw new System.ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new System.ArgumentNullException(nameof(issuer));
        }
       
    }
}