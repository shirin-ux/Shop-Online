using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Vendor
    {
        public int Id { get; set; }            
        public string Name { get; set; } = null!; 
        public string? Description { get; set; } 

        public string ContactEmail { get; set; } = null!;  
        public string? PhoneNumber { get; set; }        

        public string? Address { get; set; }          

        public double CommissionPercentage { get; set; }   

        public bool IsActive { get; set; } = true; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
