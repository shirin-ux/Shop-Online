using Shop.Application.DTOs;
using Shop.Domain.Entities;
using Shop.Domain.Factories;

namespace Shop.Application.Extention
{
    public static class OrderMappingExtensions
    {
        public static Order MapToOrder(this OrderDTO dto)
        {
            return new Order
            {
                CustomerId = dto.CustomerId,
                Products = dto.Products.Select(p => ProductFactory.CreateProduct(p.ProductType, p.Name, p.Price)).ToList(),
                ShippingMethod = dto.ShippingMethod
            };
        }
    }
}

