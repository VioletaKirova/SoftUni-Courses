namespace P03_SalesDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(k => k.CustomerId);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
        }
    }
}
