namespace PawCare.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PawCare.Data.Models;

    public class PawCareDbContext : IdentityDbContext
    {
        public PawCareDbContext(DbContextOptions<PawCareDbContext> options)
            : base(options)
        { 

        }

        public DbSet<Pet> Pets { get; set; }

    }
}