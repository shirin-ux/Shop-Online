using Shop.Domain.Entities;


namespace Shop.Domain.IRepository
{
   public interface IRefreshTokenRepository
   {
        Task<string> GenerateRefreshToken(User user, string jwtId);
   }
}
