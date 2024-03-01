using ecommerce.Enums;
using ecommerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Models.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType));
            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType));
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.DecimalType));
            builder.Property(p => p.Stock)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.IntegerType));
            builder.Property(p => p.Imagehref)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType, 1024));
            builder.Property(p => p.LastModified)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.DateTimeType));
            builder.Property(p => p.CreatedDate)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.DateTimeType));
            builder.Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.BooleanType));
        }
    }
}
