namespace PANDA.Data
{
    using Microsoft.EntityFrameworkCore;
    using PANDA.Models;

    public class PandaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Packages)
                .WithOne(p => p.Recipient);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Receipts)
                .WithOne(r => r.Recipient);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Package)
                .WithOne(p => p.Receipt);

            base.OnModelCreating(modelBuilder);
        }
    }
}
