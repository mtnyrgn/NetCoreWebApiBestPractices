using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreBestPractices.Core.Entities;

namespace NetCoreBestPractices.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(hk => hk.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Author).IsRequired().HasMaxLength(200);
            builder.Property(p => p.ISBN).IsRequired().HasMaxLength(13);
            builder.Property(p => p.PublishedDate).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
