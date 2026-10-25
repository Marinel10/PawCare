namespace PawCare.Data.Configuration
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PawCare.Data.Models;
    using PawCare.Data.Models.Enums;

    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public static readonly IEnumerable<Pet> Pets = new List<Pet>()
        {
            new Pet { Id = 1, Name = "Max", SpeciesId = 1, BreedId = 1,
                OwnerId =   UserConfiguration.DefaultUser.Id,
                BirthDate = new DateTime(2021, 4, 12), Gender = (PetGender)2, IsDeleted = false },
            new Pet { Id = 2, Name = "Bella", SpeciesId = 1, BreedId = 3,
                OwnerId = UserConfiguration.DefaultUser.Id,
                BirthDate = new DateTime(2022, 8, 5), Gender = (PetGender)1, IsDeleted = false },
            new Pet { Id = 3, Name = "Milo", SpeciesId = 2, BreedId = 6,
                OwnerId = UserConfiguration.DefaultUser.Id,
                BirthDate = new DateTime(2023, 2, 14), Gender = (PetGender)1, IsDeleted = false },
            new Pet { Id = 4, Name = "Luna", SpeciesId = 2, BreedId = 8,
                OwnerId = UserConfiguration.DefaultUser.Id,
                BirthDate = new DateTime(2020, 11, 21), Gender = (PetGender)2, IsDeleted = false },
            new Pet { Id = 5, Name = "Coco", SpeciesId = 3, BreedId = 10,
                OwnerId = UserConfiguration.DefaultUser.Id,
                BirthDate = new DateTime(2024, 1, 9), Gender = (PetGender)1, IsDeleted = false },
            new Pet { Id = 6, Name = "Kiwi", SpeciesId = 4, BreedId = 12,
                OwnerId = UserConfiguration.DefaultUser.Id,
                BirthDate = new DateTime(2023, 6, 18), Gender = (PetGender)2, IsDeleted = false },
            new Pet { Id = 7, Name = "Nibbles", SpeciesId = 5, BreedId = 14,
                OwnerId = UserConfiguration.DefaultUser.Id,
                BirthDate = new DateTime(2025, 3, 3), Gender = (PetGender)1, IsDeleted = false }
        };

        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasData(Pets);
        }
    }
}
