using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    class ProductsConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.ShoppingCart)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.ShoppingCartId)
                .HasConstraintName("FK_Products")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(p => p.Pieces)
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}
