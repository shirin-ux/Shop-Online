using Shop.Domain.Entities;

namespace Shop.Domain.IRepository
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
    }
}
