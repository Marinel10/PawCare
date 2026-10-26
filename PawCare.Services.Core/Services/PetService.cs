
namespace PawCare.Services.Core.Services
{
    using Contracts;
    using Data.Pet.Response;
    using Microsoft.EntityFrameworkCore;
    using PawCare.Data;
    using PawCare.Data.Models;
    using PawCare.Data.Models.Enums;
    using PawCare.Services.Data.Pet.Request;
    using System.Collections.Generic;
    using static GCommon.Constants.ApplicationConstatns;

    public class PetService : IPetService
    {
        private readonly PawCareDbContext dbContext;
        public PetService(PawCareDbContext dbContext)
        {   
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<GetAllPetsResponseData>> GetAllPetsAsync()
        {
            IEnumerable<GetAllPetsResponseData> allPetsResponse = await dbContext.Pets
                .Select(p => new GetAllPetsResponseData ()
                {
                    Id = p.Id,
                    Name = p.Name,
                    GenderName = p.Gender.ToString(),
                    PetImageUrl = p.PetImageUrl ?? DefaultPetImageUrl,
                    BirthDate = p.BirthDate,
                    OwnerId = p.OwnerId,
                    SpeciesName = p.Species.Name,
                    BreedName = p.Breed.Name,
                    IsDeleted = p.IsDeleted
                })
                .ToArrayAsync();

            return allPetsResponse;
        }


        public async Task<IEnumerable<GetAllPetsResponseData>> GetUserPetsAsync(string userId)
        {
            IEnumerable<GetAllPetsResponseData> pets = await dbContext.Pets
                .Where(p => p.OwnerId == userId && !p.IsDeleted)
                .Select(p => new GetAllPetsResponseData
                {
                    Id = p.Id,
                    Name = p.Name,
                    GenderName = p.Gender.ToString(),
                    PetImageUrl = p.PetImageUrl ?? DefaultPetImageUrl,
                    BirthDate = p.BirthDate,
                    OwnerId = p.OwnerId,
                    SpeciesName = p.Species.Name,
                    BreedName = p.Breed != null ? p.Breed.Name : string.Empty,
                    IsDeleted = p.IsDeleted
                })
                .ToArrayAsync();

            return pets;
        }

        public async Task<bool> CreateAsync(AddPetRequestData request)
        {
            Pet newPet = new Pet()
            {
                Name = request.Name.Trim(),
                Gender = (PetGender)request.Gender,
                BirthDate = request.BirthDate,
                PetImageUrl = request.PetImageUrl,
                SpeciesId = request.SpeciesId,
                BreedId = request.BreedId,
                OwnerId = request.OwnerId,
                IsDeleted = false
            };
            try
            {
                await dbContext.Pets.AddAsync(newPet);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
           
            return false;
        }


        public async Task<GetPetDetailsResponseData?> GetPetDetailsAsync(int petId, string userId)
        {
            GetPetDetailsResponseData? petDetailsAsync = await dbContext.Pets
                .Where(p => p.Id == petId
                            && p.OwnerId == userId
                            && !p.IsDeleted)
                .Select(p => new GetPetDetailsResponseData
                {
                    Id = p.Id,
                    Name = p.Name,
                    Gender = p.Gender.ToString(),
                    BirthDate = p.BirthDate,
                    PetImageUrl = p.PetImageUrl ?? DefaultPetImageUrl,
                    SpeciesName = p.Species.Name,
                    BreedName = p.Breed != null ? p.Breed.Name  : null!
                })
                .FirstOrDefaultAsync();

            return petDetailsAsync;
        }

        public async Task<GetPetForEditResponseData?> GetPetForEditAsync(int petId, string userId)
        {

            GetPetForEditResponseData? petForEditResponseData = await dbContext.Pets
                .Where(p => p.Id == petId
                            && p.OwnerId == userId
                            && !p.IsDeleted)
                .Select(p => new GetPetForEditResponseData
                {
                    Id = p.Id,
                    Name = p.Name,
                    Gender = (int)p.Gender,
                    BirthDate = p.BirthDate,
                    PetImageUrl = p.PetImageUrl,
                    SpeciesId = p.SpeciesId,
                    BreedId = p.BreedId
                })
                .FirstOrDefaultAsync();

            return petForEditResponseData;
        }

        public async Task<bool> EditAsync(EditPetRequestData request)
        {
            var pet = await dbContext.Pets
                .FirstOrDefaultAsync(p =>
                    p.Id == request.Id &&
                    p.OwnerId == request.OwnerId &&
                    !p.IsDeleted);

            if (pet == null)
            {
                return false;
            }

            pet.Name = request.Name;
            pet.Gender = (PetGender)request.Gender;
            pet.BirthDate = request.BirthDate;
            pet.PetImageUrl = request.PetImageUrl;
            pet.SpeciesId = request.SpeciesId;
            pet.BreedId = request.BreedId;

            await dbContext.SaveChangesAsync();

            return true;
        }



    }
}
