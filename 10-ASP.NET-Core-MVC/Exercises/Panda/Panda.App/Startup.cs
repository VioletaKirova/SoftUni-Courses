namespace Panda.App
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Panda.Data;
    using Panda.Domain;
    using System.Linq;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PandaDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<PandaUser, PandaUserRole>()
                .AddEntityFrameworkStores<PandaDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;

                options.User.RequireUniqueEmail = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<PandaDbContext>())
                {
                    dbContext.Database.EnsureCreated();

                    if (!dbContext.Roles.Any())
                    {
                        dbContext.Roles.Add(new PandaUserRole { Name = "Admin", NormalizedName = "ADMIN" });
                        dbContext.Roles.Add(new PandaUserRole { Name = "User", NormalizedName = "USER" });
                    }

                    if (!dbContext.PackageStatuses.Any())
                    {
                        dbContext.PackageStatuses.Add(new PackageStatus { Name = "Pending" });
                        dbContext.PackageStatuses.Add(new PackageStatus { Name = "Shipped" });
                        dbContext.PackageStatuses.Add(new PackageStatus { Name = "Delivered" });
                        dbContext.PackageStatuses.Add(new PackageStatus { Name = "Acquired" });                 
                    }

                    dbContext.SaveChanges();
                }
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseDeveloperExceptionPage();

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
