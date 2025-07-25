using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

using Shop.Application.IServices;
using Shop.Domain.Entities;
using Shop.Domain.IRepository;
using Shop.Infrastructure.Services;
using Xunit;

namespace Shop.Tests.UnitTests
{
    public class OrderServiceTests
    {
        private readonly IOrderRepository _orderRepositoryMock;
        private readonly IPlaceOrderService _placeOrderServiceMock;


        public OrderServiceTests()
        {
            _orderRepositoryMock = Substitute.For<IOrderRepository>();

            _placeOrderServiceMock = new PlaceOrderService(_orderRepositoryMock);
        }
        [Fact]
        public async Task PlaceOrder_Should_ThrowException_WhenTotalCostIsLessThanMinimum()
        {
            //Arrange
            var ordertest = new Order()
            {

                Products = new List<Product>()
             {
                 new Product()
                 {
                     Price = 20000
                 }
             }
            };
            //Act
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _placeOrderServiceMock.PlaceOrder(ordertest));
            //Assert
            Assert.Equal("سفارش با مبلغ کمتر از 50,000 تومان امکان‌پذیر نیست.", ex.Message);
        }

        [Fact]
        public async Task PlaceOrder_Should_ThrowException_WhenOrderIsOutsideAllowedTime()
        {
            //Arrange
            var order = new Order
            {
                CreatedAt = new DateTime(2025, 7, 2, 23, 0, 0),
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Price = 70000
                    }
                }
            };
            //Act
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(async () => await _placeOrderServiceMock.PlaceOrder(order));
            //Assert
            Assert.Equal("سفارش فقط در بازه زمانی 8 صبح تا 7 عصر قابل ثبت است.", ex.Message);
        }

    }
}
