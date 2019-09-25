namespace FDMC.Data
{
    using FDMC.Models;
    using Microsoft.EntityFrameworkCore;

    public class FdmcDbContext : DbContext
    {
        public FdmcDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
    }
}
