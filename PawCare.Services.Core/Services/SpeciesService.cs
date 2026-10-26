namespace PawCare.Services.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using PawCare.Data;
    using PawCare.Services.Core.Contracts;
    using PawCare.Services.Data.Option;

    public class SpeciesService : ISpeciesService
    {
        private readonly PawCareDbContext dbContext;
        public SpeciesService(PawCareDbContext dbContext)
        {
            this.dbContext = dbContext;
        } 

        public async Task<IEnumerable<SpeciesOptionData>> GetAllForDropdownAsync() 
        {
            IEnumerable<SpeciesOptionData> speciesOptionDatas = await dbContext.Species
                   .OrderBy(s => s.Name)
                   .Select(s => new SpeciesOptionData { Id = s.Id, Name = s.Name })
                   .ToArrayAsync();

            return speciesOptionDatas;
        }

        public async Task<bool> SpeciesExistsByIdAsync(int speciesId) 
        {
            bool speciesIsExists = await dbContext.Species
                .AnyAsync(s => s.Id == speciesId);

            return speciesIsExists;

        }
           
    }
}
