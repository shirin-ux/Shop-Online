using Shop.Application.DTOs;
using Shop.Domain.Enum;

namespace Shop.Application.IServices
{
    public interface IPaymentStrategyFactory
    {
       IPaymentStrategy Create(CustomerType customerType, decimal amount);
       PaymentRequest Process(PaymentGateway gateway, CustomerType customerType, decimal amount);
    }
}
