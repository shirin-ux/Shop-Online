namespace Shop.Application.DTOs
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public List<ProductDto> Products { get; set; } = new();
        //public ShippingMethod ShippingMethod { get; set; }
    }
}
