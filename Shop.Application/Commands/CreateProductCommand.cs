
using MediatR;

namespace Shop.Application.Commands
{
    public class CreateProductCommand:IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
