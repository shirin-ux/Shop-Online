using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.ExternalServices
{
    public class KafkaProducerService
    {
        private readonly KafkaSettings _kafkaSettings;
        private readonly IProducer<Null, string> _producer;
        private const string Topic = "order-created";


        public KafkaProducerService(IOptions<KafkaSettings> option)
        {
            _kafkaSettings = option.Value;
            var config = new ProducerConfig()
            {
                Acks = Acks.All,//تایید همه بروکرها 
                EnableIdempotence = _kafkaSettings.EnableIdempotence,
                TransactionalId = _kafkaSettings.TransactionalId,//شناسه یکتا برای ترانس اکشن ها
                BootstrapServers = _kafkaSettings.BootstrapServers  //  مشخص میکند کافکا کجا هست 
            };
            _producer = new ProducerBuilder<Null, string>(config).Build(); //پیام کلید ندارد و مقدار پیام به صورت رشته  است توسط بیلند نمونه کافکا پروسدیور ساخته میشه و میتوان پیام هارا پابلیش کرد 
            _producer.InitTransactions(TimeSpan.FromSeconds(20));

        }

        public async Task SendOrderAsync(Order order)
        {
            _producer.BeginTransaction();
            var message = JsonSerializer.Serialize(order);
            await _producer.ProduceAsync(Topic, new Message<Null, string> { Value = message });
            _producer.CommitTransaction();
        }

        public async Task SendRawAsync(string messageType, string payload) //این کد پیام را با تاپیک ارسال میکنه 
        {
            var topic = messageType switch
            {
                "ordercreated" => "order-created",
                _ => throw new ArgumentException("unknown message type")
            };
            await _producer.ProduceAsync(topic, new Message<Null, string>() { Value = payload });//پیام بدون کلید است 
                                                                                                 //مقدار پیام میشه همون payload 
        }// در کل این متد بر اساس نوع پیام تصم
    }
}
