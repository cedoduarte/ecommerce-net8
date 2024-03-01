using ecommerce.Enums;
using ecommerce.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.Models.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType));
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType));
            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType));
            builder.Property(u => u.Username)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType));
            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType, 128));
            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType));
            builder.Property(u => u.Birthdate)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.DateTimeType));
            builder.Property(u => u.Country)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType));
            builder.Property(u => u.Province)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType));
            builder.Property(u => u.City)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType));
            builder.Property(u => u.ZipCode)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.StringType, 16));
            builder.Property(u => u.Type)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.IntegerType));
            builder.Property(u => u.LastModified)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.DateTimeType));
            builder.Property(u => u.CreatedDate)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.DateTimeType));
            builder.Property(u => u.IsDeleted)
                .IsRequired()
                .HasColumnType(DatabaseTypeGetter.GetType(DataType.BooleanType));
        }
    }
}
