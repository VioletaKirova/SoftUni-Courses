namespace P03_SalesDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(k => k.StoreId);

            builder.Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode();
        }
    }
}
