namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class MedicamentConfig : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(k => k.MedicamentId);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            builder.HasMany(x => x.Prescriptions)
                .WithOne(x => x.Medicament)
                .HasForeignKey(x => x.MedicamentId);
        }
    }
}
