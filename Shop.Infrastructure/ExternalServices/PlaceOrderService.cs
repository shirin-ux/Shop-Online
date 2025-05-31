
using Shop.Application.IServices;
using Shop.Domain.Entities;
using Shop.Domain.IRepository;

namespace Shop.Infrastructure.Services
{
    public class PlaceOrderService : IPlaceOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public PlaceOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task PlaceOrder(Order order)
        {
            if (order.Products.Sum(p => p.Price) < 50000)
            {
                throw new InvalidOperationException("سفارش با مبلغ کمتر از 50,000 تومان امکان‌پذیر نیست.");
            }
            if (!order.IsValidOrderTime())
            {
                throw new InvalidOperationException("سفارش فقط در بازه زمانی 8 صبح تا 7 عصر قابل ثبت است.");
            }
            order.CalculateTotalCost();
            await _orderRepository.AddAsync(order);
        }
    }
}
