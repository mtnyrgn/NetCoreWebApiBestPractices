using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreBestPractices.Core.Models;

namespace NetCoreBestPractices.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                //default data
                new Product { Id = 1, Name = "Pilot Kale", Price = 12, Stock = 100, CategoryId = _ids[0] }
                );
        }
    }
}
