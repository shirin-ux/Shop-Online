
using Shop.Domain.Entities;

namespace Shop.Domain.IRepository
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<int> AddAsync(Product request, CancellationToken cancellationToken);
    }
}
