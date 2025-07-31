using Shop.Domain.Entities;
using Shop.Domain.IRepository;
using Shop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class RefreshTokenRepositroy(EFCoreDbContext dbcontext) : IRefreshTokenRepository
    {
        private readonly EFCoreDbContext _dbcontext= dbcontext;
        public  async Task<string> GenerateRefreshToken(User user, string jwtId)
        {
            var randomByte = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomByte);
            }
            var refreshToke = new RefreshToken
            {
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                IsRevoked = false,
                IsUsed = false,
                JwtId = jwtId,
                Token = Convert.ToBase64String(randomByte),
                user = user,
                UserId = user.Id

            };
            _dbcontext.RefreshToken.Add(refreshToke);
            await _dbcontext.SaveChangesAsync();
            return refreshToke.Token;
        }
    }
}
