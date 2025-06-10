using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
