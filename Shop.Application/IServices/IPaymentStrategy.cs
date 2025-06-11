using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTOs;
using Shop.Domain.Enum;

namespace Shop.Application.IServices
{
    public interface IPaymentStrategy
    {
        PaymentGateway Gateway { get; }
        PaymentRequest Pay(decimal amount); 
    }
}
