using Shop.Application.DTOs;
using Shop.Application.IServices;
using Shop.Domain.Enum;

namespace Shop.Infrastructure.ExternalServices
{
    public class SamanPaymentStrategy : IPaymentStrategy
    {
        public PaymentGateway Gateway => PaymentGateway.Saman;

        public PaymentRequest Pay(decimal amount)
        {
            return new PaymentRequest() { IsSuccess = true, Gateway = "Saman" };
        }
    }
}
