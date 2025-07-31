
using Shop.Domain.ValueObjects;

namespace Shop.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public Guid CustomerId { get; set; }
        public User Customer { get; set; }
       // public ShippingMethod ShippingMethod { get; set; }
        public IList<Product> Products { get; set; }

        public decimal TotalCost { get; set; }

        public DateTime CreatedAt { get; set; }
        public void CalculateTotalCost()
        {
            //TotalCost = Products.Sum(p => p.Price + p.GetPackagingCost()) + ShippingMethod.CalculateShippingCost(this);
        }
        public bool IsValidOrderTime()
        {
            var now = CreatedAt.TimeOfDay;
            return now >= TimeSpan.FromHours(8) && now <= TimeSpan.FromHours(19);
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

    }
}
