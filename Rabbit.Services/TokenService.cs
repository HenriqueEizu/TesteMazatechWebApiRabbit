using Microsoft.IdentityModel.Tokens;
using Rabbit.Model.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Rabbit.Services
{
    public class TokenService
    {
        public static object GenerateToken (RabbitMessage message)
        {
            var key = Encoding.UTF32.GetBytes(Key.Secret);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim ("numeroProtocolo", message.numeroProtocolo.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                //SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken (tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new { token =  tokenString };
        }
    }
}
