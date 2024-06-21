using managementtaskexercice.Application.Contracts.Users.Login;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Authentication.Token
{
    public class GenerateToken : IGenerateToken
    {

        public string CreateToken(IEnumerable<Claim> Claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("vanleroy53@gmail.comvanleroy53@gmail.comvanleroy53@gmail.com"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:7255",
                audience: "https://localhost:7255",
                claims: Claims,
            expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }


    }
}
