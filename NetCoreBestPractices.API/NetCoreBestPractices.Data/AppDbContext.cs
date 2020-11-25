using System;
using Microsoft.EntityFrameworkCore;
using NetCoreBestPractices.Core.Models;
using NetCoreBestPractices.Data.Configurations;
using NetCoreBestPractices.Data.Seeds;

namespace NetCoreBestPractices.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));//default datalar uygulanıyor
        }
    }


}
