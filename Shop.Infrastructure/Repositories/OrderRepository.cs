using Shop.Domain.Entities;

using Shop.Domain.IRepository;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EFCoreDbContext _dbContext;
        public OrderRepository(EFCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
  
        public async Task AddAsync(Order order)
        {
            await _dbContext.AddAsync(order);
        }


    }
}
