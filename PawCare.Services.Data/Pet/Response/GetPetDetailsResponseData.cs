
namespace PawCare.Services.Data.Pet.Response
{
    public class GetPetDetailsResponseData
    {
        public int Id { get; set; }


        public string Name { get; set; } = null!;

        public string Gender { get; set; }

        public string? PetImageUrl { get; set; }


        public DateTime BirthDate { get; set; }

        public string SpeciesName { get; set; }

        public string BreedName { get; set; }

        public string OwnerId { get; set; } = null!;
    }
}
