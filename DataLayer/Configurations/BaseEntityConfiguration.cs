using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    public abstract class BaseEntityConfiguration
    {
        public void Configure<T>(EntityTypeBuilder<T> builder)
            where T: BaseEntity
        {
            builder.HasKey(p => p.Id);

            builder.Property(t => t.Id)
                .IsRequired();
        }
    }
}
