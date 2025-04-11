using MediatR;
using Shop.Domain.Interface;

namespace Shop.Application.Commands
{
    public class CreateProductHandler(IApplicationDbContext context) : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context = context;
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
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
