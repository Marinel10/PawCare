namespace PawCare.Data.Configuration
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PawCare.Data.Models;

    public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
    {
        public static readonly IEnumerable<Procedure> Procedures = new List<Procedure>()
        {
            new Procedure { Id = 1, Name = "General Examination", Description = "Routine veterinary examination", Price = 30.00m },
            new Procedure { Id = 2, Name = "Vaccination", Description = "Standard pet vaccination", Price = 45.00m },
            new Procedure { Id = 3, Name = "Blood Test", Description = "Laboratory blood examination", Price = 60.00m },
            new Procedure { Id = 4, Name = "Microchipping", Description = "Pet identification microchip", Price = 40.00m },
            new Procedure { Id = 5, Name = "Deworming", Description = "Internal parasite treatment", Price = 25.00m },
            new Procedure { Id = 6, Name = "Ultrasound", Description = "Diagnostic ultrasound examination", Price = 75.00m },
            new Procedure { Id = 7, Name = "X-ray", Description = "Diagnostic radiography", Price = 80.00m },
            new Procedure { Id = 8, Name = "Dental Cleaning", Description = "Professional dental cleaning", Price = 120.00m }
        };

        public void Configure(EntityTypeBuilder<Procedure> builder)
        {
            builder.HasData(Procedures);
        }
    }
}
