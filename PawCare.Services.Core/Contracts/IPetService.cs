namespace PawCare.Services.Core.Contracts
{
    using PawCare.Services.Data.Pet.Response;
    using PawCare.Services.Data.Pet.Request;

    public interface IPetService
    {
        Task<IEnumerable<GetAllPetsResponseData>> GetAllPetsAsync();

        Task<IEnumerable<GetAllPetsResponseData>> GetUserPetsAsync(string userId);

        Task<bool> CreateAsync(AddPetRequestData request);


        Task<GetPetDetailsResponseData?> GetPetDetailsAsync(int petId, string userId);

        Task<GetPetForEditResponseData?> GetPetForEditAsync(int petId, string userId);

        Task<bool> EditAsync(EditPetRequestData request);


    }
}
