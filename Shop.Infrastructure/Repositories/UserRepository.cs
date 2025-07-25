using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.IRepository;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Repositories
{
   public class UserRepository(EFCoreDbContext dbContext) :IUserRepository
   {
        private readonly EFCoreDbContext _dbContext=dbContext;
        public async Task<User> IsUser(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId); //find is faster than FirstOrDefault
            return user;
        }

        public async Task<User> GetByUserName(string userName)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName== userName);
            return user;
        }
    }
}
