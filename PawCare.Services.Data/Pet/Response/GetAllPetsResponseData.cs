
namespace PawCare.Services.Data.Pet.Response
{
    public class GetAllPetsResponseData
    {
        public int Id { get; set; }


        public string Name { get; set; } = null!;

        public string GenderName { get; set; }

        public string? PetImageUrl { get; set; }


        public DateTime BirthDate { get; set; }

        public string OwnerId { get; set; } = null!;

        public string SpeciesName { get; set; } = null!;

        public string BreedName { get; set; }


        public bool IsDeleted { get; set; } = false;



    }
}
