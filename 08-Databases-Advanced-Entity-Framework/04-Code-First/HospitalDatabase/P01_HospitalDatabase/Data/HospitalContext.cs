namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=.;Database=Hospital;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsUnicode();

                entity.Property(e => e.LastName)
                    .IsUnicode();

                entity.Property(e => e.Address)
                    .IsUnicode();

                entity.Property(e => e.Email)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsUnicode();

                entity.Property(e => e.Comments)
                    .IsUnicode();
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsUnicode();
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.Property(e => e.Comments)
                    .IsUnicode();
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(k => new { k.PatientId, k.MedicamentId });
            });
        }
    }
}
