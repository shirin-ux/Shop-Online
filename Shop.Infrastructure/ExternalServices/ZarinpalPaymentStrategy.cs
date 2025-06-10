using Shop.Application.DTOs;
using Shop.Application.IServices;
using Shop.Domain.Enum;

namespace Shop.Infrastructure.ExternalServices
{
    public class ZarinpalPaymentStrategy : IPaymentStrategy
    {
        public PaymentGateway Gateway => PaymentGateway.Zarinpal;

        public async Task<PaymentRequest> PayAsync(PaymentRequest request)
        {
            
            return new PaymentRequest { IsSuccess = true, Gateway = "Zarinpal" };
        }
    }
}