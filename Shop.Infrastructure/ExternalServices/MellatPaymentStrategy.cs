using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTOs;
using Shop.Application.IServices;
using Shop.Domain.Enum;

namespace Shop.Infrastructure.ExternalServices
{
    public class MellatPaymentStrategy:IPaymentStrategy
    {
        public PaymentGateway Gateway => PaymentGateway.Mellat;

        public PaymentRequest Pay(decimal amount)
        {
            return  new PaymentRequest() { IsSuccess = true, Gateway = "Mellat" };
        }
    }
}

