using Shop.Domain.Entities;

namespace Shop.Domain.IRepository
{
    public interface IOrderRepository
    {
        Task AddOrderWithOutboxAsync(Order order,OutboxMessage outBoxMessage);
    }
}
