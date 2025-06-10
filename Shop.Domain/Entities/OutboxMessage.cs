using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
   public  class OutboxMessage
    {
        public Guid Id { get; set; }

        public Guid AggregateId { get; set; }

        public string Type { get; set; }

        public string Payload { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsPublished { get; set; } = false;
    }
}
