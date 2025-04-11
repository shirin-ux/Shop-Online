using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Factories
{

        public static class ProductFactory
        {
            public static Product CreateProduct(string productType, string name, decimal price)
            {
                return productType switch
                {
                    //"Fragile" => new FragileProduct { Name = name, Price = price },
                    //"Regular" => new RegularProduct { Name = name, Price = price },
                    _ => throw new ArgumentException("Invalid product type")
                };
            }
        }
    }

