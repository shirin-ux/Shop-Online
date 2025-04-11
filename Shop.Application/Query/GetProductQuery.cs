using MediatR;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Query
{
    public class GetProductQuery:IRequest<List<Product>>
    {
    }
}
