namespace PawCare.Data.Configuration
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PawCare.Data.Models;

    public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public static readonly IEnumerable<Species> Species = new List<Species>()
        {
            new Species { Id = 1, Name = "Dog" },
            new Species { Id = 2, Name = "Cat" },
            new Species { Id = 3, Name = "Rabbit" },
            new Species { Id = 4, Name = "Bird" },
            new Species { Id = 5, Name = "Hamster" }
        };

        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasData(Species);
        }
    }
}
