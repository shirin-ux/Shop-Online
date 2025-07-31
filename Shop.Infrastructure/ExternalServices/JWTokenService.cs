using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.DTOs;
using Shop.Application.IServices;
using Shop.Domain.IRepository;
using Shop.Infrastructure.Shared;

namespace Shop.Infrastructure.ExternalServices
{
   public class JWTokenService(IOptions<AppSetting> config,IRefreshTokenRepository refreshTokenRepository):ITokenService
   {
        private readonly IOptions<AppSetting> _config=config;
        private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;
        public AccessTokenResultDto GenerateTokenAccess(UserDto userDto)
        {
            var jwtId = Guid.NewGuid().ToString();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userDto.id.ToString()),
                new Claim(ClaimTypes.Name, userDto.username),
                new Claim(ClaimTypes.Role, userDto.role),
                new Claim(JwtRegisteredClaimNames.Jti,jwtId)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.SecurityKey));
            var cards = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.UtcNow.AddMinutes(15);
            var token = new JwtSecurityToken(

                issuer: _config.Value.Issue,
                audience: _config.Value.Audience,
                claims: claims,
                expires: expiry,
                signingCredentials: cards);
           var tokenString= new JwtSecurityTokenHandler().WriteToken(token);
            return new AccessTokenResultDto
            {
                Token = tokenString,
                ExpireAt = expiry,
                JwtId = jwtId
            };
        }

        public async Task<string> GenerateRefreshToken(UserDto user, string jwtId)
        {
         return  await _refreshTokenRepository.GenerateRefreshToken(new Domain.Entities.User
           {
               Role=user.role,
               UserName=user.username,
                Id=user.id 
           }, jwtId);
        }
    }
}
