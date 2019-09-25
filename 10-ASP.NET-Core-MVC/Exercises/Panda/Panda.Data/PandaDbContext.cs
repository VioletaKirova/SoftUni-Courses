namespace Panda.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Panda.Domain;

    public class PandaDbContext : IdentityDbContext<PandaUser, PandaUserRole, string>
    {
        public DbSet<Package> Packages { get; set; }

        public DbSet<PackageStatus> PackageStatuses { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public PandaDbContext()
        {
        }

        public PandaDbContext(DbContextOptions<PandaDbContext> options) 
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-8GP0VTJ\\SQLEXPRESS;Database=PandaDb;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PandaUser>()
                .HasKey(user => user.Id);

            builder.Entity<Package>()
                .HasKey(package => package.Id);

            builder.Entity<Receipt>()
                .HasKey(receipt => receipt.Id);

            builder.Entity<PandaUser>()
                .HasMany(user => user.Packages)
                .WithOne(package => package.Recipient)
                .HasForeignKey(package => package.RecipientId);

            builder.Entity<PandaUser>()
                .HasMany(user => user.Receipts)
                .WithOne(receipt => receipt.Recipient)
                .HasForeignKey(receipt => receipt.RecipientId);

            builder.Entity<Receipt>()
                .HasOne(receipt => receipt.Package)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
