using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.DataAccess.Repository.Token
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;
        public TokenRepository(IConfiguration configuratio) 
        {
            this.configuration = configuratio;
        }
        public string CreateJWTToken(IdentityUser user, List<string> roles)
        {
            var Claims = new List<Claim>();
            Claims.Add(new Claim(ClaimTypes.Email, user.Email));

            foreach(var role in roles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var Credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512);

            // Generating Tokens
            var Token = new JwtSecurityToken
                (
                    configuration["JWT:Issuer"],
                    configuration["JWT:Audiance"],
                    Claims,
                    expires:DateTime.Now.AddMinutes(15),
                    signingCredentials : Credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
