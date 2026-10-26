namespace PawCare.ViewModels.Pet
{

    using PawCare.ViewModels.Breed;
    using PawCare.ViewModels.Species;
    using System.ComponentModel.DataAnnotations;
    using static PawCare.GCommon.Constants.ValidationConstants.Pet;

    public class EditPetInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMax, MinimumLength = NameMin)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a gender.")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "Please enter a birth date.")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(PetImageUrlMax)]
        [Url(ErrorMessage = "Please enter a valid image URL.")]
        public string? PetImageUrl { get; set; }
        public int SpeciesId { get; set; }

        public int? BreedId { get; set; }


        public IEnumerable<SpeciesViewModel> Species { get; set; }
            = new List<SpeciesViewModel>();
        public IEnumerable<BreedViewModel> Breeds { get; set; }
         = new List<BreedViewModel>();
    }
}
