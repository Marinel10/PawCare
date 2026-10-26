namespace PawCare.Services.Data.Pet.Request
{
    public class EditPetRequestData
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string OwnerId { get; set; } = null!;
        public int SpeciesId { get; set; }
        public int? BreedId { get; set; }
        public int Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PetImageUrl { get; set; }
    }
}
