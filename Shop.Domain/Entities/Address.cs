using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FullAddress { get; set; }
        public string PostalCode { get; set; }

        public User User { get; set; }
    }
}
