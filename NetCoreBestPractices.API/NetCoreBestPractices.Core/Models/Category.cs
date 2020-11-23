using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetCoreBestPractices.Core.Models
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public Collection<Product> Products { get; set; }
    }
}
