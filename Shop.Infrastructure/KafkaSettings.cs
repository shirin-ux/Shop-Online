using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure
{
    public class KafkaSettings
    {
        public string BootstrapServers { get; set; }
        public string GroupId { get; set; }
        public string AutoOffsetReset { get; set; }
        public bool EnableAutoCommit { get; set; }
        public  bool EnableIdempotence { get; set; }
        public string TransactionalId { get; set; }
    }
}
