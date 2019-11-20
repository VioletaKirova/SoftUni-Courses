namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(k => k.PatientId);

            builder.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode();

            builder.Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.HasMany(x => x.Prescriptions)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId);

            builder.HasMany(x => x.Visitations)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId);

            builder.HasMany(x => x.Diagnoses)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId);
        }
    }
}
