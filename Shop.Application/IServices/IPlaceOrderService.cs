
using Shop.Domain.Entities;

namespace Shop.Application.IServices
{
    public interface IPlaceOrderService
    {
        Task PlaceOrder(Order order);
    }
}
