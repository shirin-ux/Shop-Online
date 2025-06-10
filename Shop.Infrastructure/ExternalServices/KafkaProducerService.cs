using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Shop.Application.DTOs;
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
               BootstrapServers = _kafkaSettings.BootstrapServers  //  مشخص میکند کافکا کجا هست 
           };
            _producer = new ProducerBuilder<Null, string>(config).Build(); //پیام کلید ندارد و مقدار پیام به صورت string  است توسط بیلند نمونه کافکا پروسدیور ساخته میشه و میتوان پیام هارا پابلیش کرد 

        }

       public async Task SendOrderAsync(Order order)
       {
           var message = JsonSerializer.Serialize(order);
           await _producer.ProduceAsync(Topic, new Message<Null, string> { Value = message });
       }

       public async Task SendRawAsync(string messageType, string payload)
       {
           var topic = messageType switch
           {
               "ordercreated" => "order-created",
               _ => throw new ArgumentException("unknown message type")
           };
           await _producer.ProduceAsync(topic, new Message<Null, string>() { Value = payload });
       }
    }
}
