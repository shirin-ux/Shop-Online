using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Shop.Domain.Entities;
using Shop.Domain.Interface;
using Shop.Domain.IRepository;

namespace Shop.Infrastructure.Repositories
{
    public class ProductRepository(IApplicationDbContext context) : IProductRepository
    {
        private readonly IApplicationDbContext _context = context;
        public async Task<Product?> GetByIdAsync(int id) =>await _context.Products.FindAsync(id);

        public async Task<int> AddAsync(Product request , CancellationToken cancellationToken)
        {
           var product = new Domain.Entities.Product
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Price = request.Price
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product.Id;
        }

    }
}
