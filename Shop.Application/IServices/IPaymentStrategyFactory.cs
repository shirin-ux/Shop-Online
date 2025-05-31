using Shop.Domain.Enum;

namespace Shop.Application.IServices
{
    public interface IPaymentStrategyFactory
    {
        IPaymentStrategy Create(CustomerType customerType, decimal amount);
    }
}
