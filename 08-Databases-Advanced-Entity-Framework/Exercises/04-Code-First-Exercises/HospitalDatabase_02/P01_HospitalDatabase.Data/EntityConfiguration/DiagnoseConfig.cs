namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class DiagnoseConfig : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder.HasKey(k => k.DiagnoseId);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }
    }
}
