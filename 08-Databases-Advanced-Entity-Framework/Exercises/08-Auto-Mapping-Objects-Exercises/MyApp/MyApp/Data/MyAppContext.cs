namespace MyApp.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class MyAppContext : DbContext
    {
        //public MyAppContext()
        //{

        //}

        public MyAppContext(DbContextOptions<MyAppContext> options) 
            : base(options)
        {

        }     

        public DbSet<Employee> Employees { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseSqlServer("Server=.;Database=MyApp;Integrated Security=True;");
        //}
    }
}
