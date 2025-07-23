using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.DTOs;
using Shop.Application.IServices;
using Shop.Infrastructure.Shared;

namespace Shop.Infrastructure.ExternalServices
{
   public class JWTokenService(IOptions<AppSetting> config):ITokenService
   {
        private readonly IOptions<AppSetting> _config=config;
        public string GenerateTokenAccess(UserDto userDto)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userDto.id.ToString()),
                new Claim(ClaimTypes.Name, userDto.username),
                new Claim(ClaimTypes.Role, userDto.role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.SecurityKey));
            var cards = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                issuer: _config.Value.Issue,
                audience: _config.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: cards);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}
