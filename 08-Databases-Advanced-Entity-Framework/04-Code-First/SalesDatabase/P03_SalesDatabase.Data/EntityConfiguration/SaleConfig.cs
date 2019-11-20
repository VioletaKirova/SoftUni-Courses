namespace P03_SalesDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(k => k.SaleId);

            builder.Property(p => p.Date)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Store)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.StoreId);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Sales)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
