using System;
using Microsoft.IdentityModel.Tokens.JWT;

namespace Gear
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = new JWTSecurityToken(
                issuer: "http://myIssuer",
                audience: "http://myResource",
                claims: GetClaims(),
                signingCredentials: GetKey(),
                validForm: DateTime.UtcNow,
                validTo: DateTime.UtcNow.AddHours(1)
            );

            var tokenString =
                new JWTSecurityTokenHandler().WriteToken(token);

            Console.WriteLine(tokenString);
        }
    }
}
