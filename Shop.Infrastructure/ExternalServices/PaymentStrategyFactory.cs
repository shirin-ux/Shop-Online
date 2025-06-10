using Microsoft.AspNetCore.Http.HttpResults;
using Shop.Application.IServices;
using Shop.Domain.Enum;

namespace Shop.Infrastructure.ExternalServices
{
  public  class PaymentStrategyFactory: IPaymentStrategyFactory
    {
        public readonly IEnumerable<IPaymentStrategy> _paymentStrategy;
        public PaymentStrategyFactory(IEnumerable<IPaymentStrategy> paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }
        public  IPaymentStrategy Create(CustomerType customerType, decimal amount)
        {
            PaymentGateway selectedGateway;
            if (customerType == CustomerType.Vip && amount > 5_000_000)
                selectedGateway = PaymentGateway.Mellat;
            else if (customerType == CustomerType.Vip)
                selectedGateway = PaymentGateway.Saman;
            else
                selectedGateway = PaymentGateway.Zarinpal;

            return _paymentStrategy.First(s => s.Gateway == selectedGateway);


        }
    }
}
