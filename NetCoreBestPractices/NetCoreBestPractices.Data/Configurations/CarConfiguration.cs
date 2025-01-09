using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreBestPractices.Core.Entities;

namespace NetCoreBestPractices.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(hk => hk.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Make).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Model).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Year).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
            builder.ToTable("Cars");
        }
    }
}
