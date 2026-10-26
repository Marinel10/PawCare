namespace PawCare.Services.Core.Contracts
{
    using PawCare.Services.Data.Option;
    using PawCare.Services.Data.Pet.Request;
    using PawCare.Services.Data.Pet.Response;

    public interface ISpeciesService
    {
        Task<IEnumerable<SpeciesOptionData>> GetAllForDropdownAsync();

        Task<bool> SpeciesExistsByIdAsync(int speciesId);



    }
}
