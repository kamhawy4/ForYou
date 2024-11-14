using ForYou.Application.Common.Helpers;
using ForYou.Application.Services.Interfaces;
using ForYou.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Infrastructure.Services.Web
{
    public class WebTokenService : IWebTokenService
    {

        private readonly AppSettings _appSettings;

        public WebTokenService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public string GetToken(UserEntity user)
        {
          var tokenHandler =   new JwtSecurityTokenHandler();

           var key =  Encoding.UTF8.GetBytes(_appSettings.JwtSettings.JwtEncryptionKey);

            var claims = new List<Claim>
            {
              //  new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
               // new Claim(ClaimTypes.Name, user.FirstName),
                //new Claim(ClaimTypes.Email, user.Email),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.JwtSettings.JwtExpireAfterMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _appSettings.JwtSettings.Audience,
                Issuer = _appSettings.JwtSettings.Issuer

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32]; // Generates a 32-byte array
            var random = RandomNumberGenerator.Create();
            using (random)
            {
                random.GetBytes(randomNumber);
            }

            return Convert.ToBase64String(randomNumber);
        }

    }
}
