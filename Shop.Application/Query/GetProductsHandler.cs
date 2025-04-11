using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Query
{
    public class GetProductsHandler(IApplicationDbContext context) : IRequestHandler<GetProductQuery, List<Product>>
    {
        private readonly IApplicationDbContext _contex=context;
        public async Task<List<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _contex.Products.ToListAsync(cancellationToken);
        }
    }
}
