namespace PawCare.Services.Core.Services
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using PawCare.Data;
    using PawCare.Services.Core.Contracts;
    using PawCare.Services.Data.Option;

    public class BreedService : IBreedService
    {
        private readonly PawCareDbContext dbContext;
        public BreedService(PawCareDbContext dbContext) 
        {
            this.dbContext = dbContext;
        } 

        public async Task<IEnumerable<BreedOptionData>> BreedsGetBySpeciesIdAsync(int speciesId)
        {
            IEnumerable<BreedOptionData> breedOptionData = await dbContext.Breeds
                .Where(b => b.SpeciesId == speciesId)
                .OrderBy(b => b.Name)
                .Select(b => new BreedOptionData { Id = b.Id, Name = b.Name })
                .ToArrayAsync();

            return breedOptionData;

        }

        public async Task<bool> BelongsToSpeciesAsync(int breedId, int speciesId) 
        {
            bool IsBreedBelongToSpecies = await dbContext.Breeds
                    .AnyAsync(b => b.Id == breedId && b.SpeciesId == speciesId);

            return IsBreedBelongToSpecies;

        }
            
    }

}