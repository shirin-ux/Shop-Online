using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public abstract class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public abstract decimal GetPackagingCost();
    }
    public class RegularProduct : Product
    {
        public override decimal GetPackagingCost() => 0;
    }
    public class FragileProduct : Product
    {
        public override decimal GetPackagingCost() => 5000;
    }

}
