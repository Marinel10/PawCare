
namespace PawCare
{
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using PawCare.Services.Core.Contracts;
    using PawCare.Services.Core.Services;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = builder.Configuration
                .GetConnectionString("SqlServerDev")
                ?? throw new InvalidOperationException("Connection string 'SqlServerDev' not found.");


            builder.Services.AddDbContext<PawCareDbContext>(options =>
            { 
                options.UseSqlServer(connectionString);             
            });

            builder.Services.AddScoped<ISpeciesService, SpeciesService>();
            builder.Services.AddScoped<IBreedService, BreedService>();
            builder.Services.AddScoped<IPetService, PetService>();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {

                options.SignIn.RequireConfirmedAccount = false;

             }).AddEntityFrameworkStores<PawCareDbContext>();

            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
