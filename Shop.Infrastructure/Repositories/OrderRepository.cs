using System.Runtime.InteropServices.ComTypes;
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

        public async Task AddOrderWithOutboxAsync(Order order, OutboxMessage outBoxMessage)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {

                await _dbContext.Orders.AddAsync(order);
                await _dbContext.OutboxMessages.AddAsync(outBoxMessage);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


    }
}
