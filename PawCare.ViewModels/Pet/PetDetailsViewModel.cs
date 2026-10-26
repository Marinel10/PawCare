namespace PawCare.ViewModels.Pet
{

    using PawCare.ViewModels.Breed;
    using PawCare.ViewModels.Species;
    using System.ComponentModel.DataAnnotations;
    using static PawCare.GCommon.Constants.ValidationConstants.Pet;

    public class PetDetailsViewModel
    {
        public int Id { get; set; }


        public string Name { get; set; } = null!;


        public string Gender { get; set; }


        public DateTime? BirthDate { get; set; }


        public string? PetImageUrl { get; set; }
        public string SpeciesName { get; set; }

        public string BreedName { get; set; }


    }
}
