﻿namespace Shop.Domain.Entities
{
    public  class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int VendorId { get; set; }
        public Category Category { get; set; } = default!;
        public Inventory Inventory { get; set; } = default!;
        public Vendor Vendor { get; set; } = default!;
    }


}
