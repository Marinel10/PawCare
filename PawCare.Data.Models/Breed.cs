


namespace PawCare.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static PawCare.GCommon.Constants.ValidationConstants.Breed;
    /// <summary>
    /// Represents a breed of an animal species.
    /// </summary>
    public class Breed
    {
        /// <summary>
        /// Gets or sets the unique identifier of the breed.
        /// </summary>
        [Key]
        [Comment("Unique identifier of the breed")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the breed.
        /// </summary>
        [Required]
        [StringLength(NameMax, MinimumLength = NameMin)]
        [Comment("Name of the breed")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the identifier of the species
        /// to which the breed belongs.
        /// </summary>
        [Comment("Foreign key to the species")]
        public int SpeciesId { get; set; }

        /// <summary>
        /// Gets or sets the species to which the breed belongs.
        /// </summary>
        public virtual Species Species { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of pets belonging to this breed.
        /// </summary>
        public virtual ICollection<Pet> Pets { get; set; }
            = new HashSet<Pet>();
    }
}
