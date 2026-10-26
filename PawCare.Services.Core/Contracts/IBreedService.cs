namespace PawCare.Services.Core.Contracts
{
    using PawCare.Services.Data.Option;

    public interface IBreedService
    {
        Task<IEnumerable<BreedOptionData>> BreedsGetBySpeciesIdAsync(int speciesId);
        Task<bool> BelongsToSpeciesAsync(int breedId, int speciesId);
    }
}