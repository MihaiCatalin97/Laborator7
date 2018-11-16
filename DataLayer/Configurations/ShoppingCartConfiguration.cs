using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    class ShoppingCartConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Date)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();
        }
    }
}
