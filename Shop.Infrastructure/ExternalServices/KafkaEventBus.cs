using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.IServices;

namespace Shop.Infrastructure.ExternalServices
{
    public class KafkaEventBus:IEventBus
    {
        public Task PublishAsync<T>(T message)
        {
            throw new NotImplementedException();
        }
    }
}
