﻿using System;
namespace NetCoreBestPractices.Core.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public long Stock { get; set; }
        public string InnerBarcode { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Category Category { get; set; }
    }
}
