namespace PawCare.Data.Configuration
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PawCare.Data.Models;

    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public readonly IEnumerable<Breed> Breeds = new List<Breed>()
        {
            new Breed { Id = 1, Name = "Labrador Retriever", SpeciesId = 1 },
            new Breed { Id = 2, Name = "German Shepherd", SpeciesId = 1 },
            new Breed { Id = 3, Name = "Golden Retriever", SpeciesId = 1 },
            new Breed { Id = 4, Name = "Bulldog", SpeciesId = 1 },
            new Breed { Id = 5, Name = "Beagle", SpeciesId = 1 },
            new Breed { Id = 6, Name = "British Shorthair", SpeciesId = 2 },
            new Breed { Id = 7, Name = "Persian", SpeciesId = 2 },
            new Breed { Id = 8, Name = "Maine Coon", SpeciesId = 2 },
            new Breed { Id = 9, Name = "Siamese", SpeciesId = 2 },
            new Breed { Id = 10, Name = "Holland Lop", SpeciesId = 3 },
            new Breed { Id = 11, Name = "Netherland Dwarf", SpeciesId = 3 },
            new Breed { Id = 12, Name = "Budgerigar", SpeciesId = 4 },
            new Breed { Id = 13, Name = "Cockatiel", SpeciesId = 4 },
            new Breed { Id = 14, Name = "Syrian Hamster", SpeciesId = 5 },
            new Breed { Id = 15, Name = "Dwarf Hamster", SpeciesId = 5 },
            new Breed { Id = 16, Name = "Miniature Pinscher", SpeciesId = 1 },
            new Breed { Id = 17, Name = "Cavalier King Charles Spaniel", SpeciesId = 1 }

        };

        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.HasData(Breeds);
        }
    }
}
