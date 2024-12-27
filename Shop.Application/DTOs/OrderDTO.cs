using Shop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTOs
{
     public class OrderDTO
    {
        public Guid CustomerId { get; set; }
        public List<ProductDto> Products { get; set; } = new();
        public ShippingMethod ShippingMethod { get; set; }
    }
}
