namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class ResourceConfig : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(r => r.ResourceId);

            builder.Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(r => r.Url)
                .IsRequired();

            builder.Property(r => r.ResourceType)
               .IsRequired();
        }
    }
}
