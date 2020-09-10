using Microsoft.AspNetCore.Authentication;

namespace WebLab
{
    internal class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string Realm { get; set; }
    }
}