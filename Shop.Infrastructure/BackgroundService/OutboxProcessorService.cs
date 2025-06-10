using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shop.Infrastructure.ExternalServices;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.BackgroundService
{
   public class OutboxProcessorService(IServiceProvider serviceProvider, 
                                         ILogger<OutboxProcessorService> logger,
                                         KafkaProducerService kafkaProducer) :Microsoft.Extensions.Hosting.BackgroundService
   {
       private readonly IServiceProvider _serviceProvider= serviceProvider;
       private readonly ILogger<OutboxProcessorService> _logger= logger;
       private readonly KafkaProducerService _kafkaProducer= kafkaProducer;
       protected override async Task ExecuteAsync(CancellationToken stoppingToken)
       {
           while (!stoppingToken.IsCancellationRequested)
           {
               using var scope = _serviceProvider.CreateScope();
               var dbContext = scope.ServiceProvider.GetRequiredService<EFCoreDbContext>();
               var outBoxMessages=await dbContext.OutboxMessages
                   .Where(x => !x.IsPublished)
                   .OrderBy(x => x.CreatedAt)
                   .Take(10)
                   .ToListAsync(stoppingToken);
               foreach (var message in outBoxMessages)
               {
                   await _kafkaProducer.SendRawAsync(message.Type, message.Payload);
                   message.IsPublished = true;
                   dbContext.OutboxMessages.Update(message);
               }

               await dbContext.SaveChangesAsync(stoppingToken);
               await Task.Delay(2000, stoppingToken);
           }
       }
   }
}
