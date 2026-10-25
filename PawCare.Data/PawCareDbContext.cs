namespace PawCare.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PawCare.Data.Models;

    /// <summary>
    /// Represents the database context for the PawCare application.
    /// </summary>
    public class PawCareDbContext : IdentityDbContext
    {
        public PawCareDbContext(DbContextOptions<PawCareDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pet> Pets { get; set; } = null!;

        public virtual DbSet<Species> Species { get; set; } = null!;

        public virtual DbSet<Breed> Breeds { get; set; } = null!;

        public virtual DbSet<Procedure> Procedures { get; set; } = null!;

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;

        public virtual DbSet<AppointmentProcedure> AppointmentProcedures { get; set; } = null!;

        public virtual DbSet<MedicalRecord> MedicalRecords { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }

    }
}