using Shop.Application.DTOs;
using Shop.Application.IServices;
using Shop.Domain.Enum;

namespace Shop.Infrastructure.ExternalServices
{
    public class SamanPaymentStrategy : IPaymentStrategy
    {
        public PaymentGateway Gateway => PaymentGateway.Saman;

        public Task<PaymentRequest> PayAsync(PaymentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
