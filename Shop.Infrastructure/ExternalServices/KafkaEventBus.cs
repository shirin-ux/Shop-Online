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
