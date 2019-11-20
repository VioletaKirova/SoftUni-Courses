namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(k => k.DoctorId);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(p => p.Specialty)
                .HasMaxLength(100)
                .IsUnicode();

            builder.HasMany(x => x.Visitations)
                .WithOne(x => x.Doctor)
                .HasForeignKey(x => x.DoctorId);
        }
    }
}
