namespace Eventures.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Threading.Tasks;

    public class EventuresUserRoleSeeder : ISeeder
    {
        private readonly EventuresDbContext dbContext;

        public EventuresUserRoleSeeder(EventuresDbContext context)
        {
            this.dbContext = context;
        }

        public async Task Seed()
        {
            if (!dbContext.Roles.Any())
            {
                dbContext.Roles.Add(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

                dbContext.Roles.Add(new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                });
            }

            dbContext.SaveChanges();
        }
    }
}
