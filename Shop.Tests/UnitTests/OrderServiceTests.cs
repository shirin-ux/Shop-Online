using Moq;
using Shop.Domain.Entities;
using Shop.Domain.IRepository;
using Shop.Infrastructure.Services;
using Xunit;

namespace Shop.Tests.UnitTests
{
    public class OrderServiceTests
    {
        [Fact]
        public async Task PlaceOrder_ShouldThrowException_WhenTotalCostIsLessThanMinimum()
        {
            var order = new Order
            {
                Products = new List<Product>
                { 
                // new RegularProduct { Price = 20000 }
                }
            };

            var service = new PlaceOrderService(new Mock<IOrderRepository>().Object,);

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await service.PlaceOrder(order));
        }

        [Fact]
        public async Task PlaceOrder_ShouldThrowException_WhenOrderIsOutsideAllowedTime()
        {
            var order = new Order
            {
                Products = new List<Product>
                {
                  // new RegularProduct { Price = 60000 }
                },
                 CreatedAt=DateTime.Now.AddHours(20)
            };

            var service = new PlaceOrderService(new Mock<IOrderRepository>().Object);

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await service.PlaceOrder(order));
        }

    }
}
