using MediatR;
using Shop.Domain.Entities;
using Shop.Domain.Interface;
using Shop.Domain.IRepository;

namespace Shop.Application.Commands
{
    public class CreateProductHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepositorty= productRepository;
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
         return await _productRepositorty.AddAsync(new Product()
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                 Price = request.Price
            }, cancellationToken);
        }
    }
}
