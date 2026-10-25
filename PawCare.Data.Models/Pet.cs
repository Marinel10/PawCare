
namespace PawCare.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using PawCare.Data.Models.Enums;
    using static PawCare.GCommon.Constants.ValidationConstants.Pet;

    /// <summary>
    /// Represents a pet in the veterinary clinic.
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Gets or sets the unique Id of the pet.
        /// </summary>
        [Key]
        [Comment("Primary key")]
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets the name of the pet.
        /// </summary>
        [Required]
        [StringLength(NameMax)]
        [Comment("Name of the pet")]
        public string Name { get; set; } = null!;



        /// <summary>
        /// Gets or sets the gender of the pet from enum.
        /// </summary>

        [Comment("Pet's gender")]
        public PetGender Gender { get; set; }


        /// <summary>
        /// Gets or sets the optional profile image URL of the pet.
        /// </summary>

        [StringLength(PetImageUrlMax)]
        [Comment("Pet profile image")]
        public string? PetImageUrl { get; set; }


        /// <summary>
        /// Gets or sets the date of birth of the pet.
        /// </summary>
        [Required]
        [Column(TypeName = BirthDateColumnType)]
        [Comment("Pet's date of birth")]
        public DateTime BirthDate { get; set; }



        /// <summary>
        /// Gets or sets the unique Id of the pet's owner.
        /// </summary>
        [Required]
        [Comment("ID of the pet owner")]
        public string OwnerId { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user who owns the pet.
        /// </summary>
        [ForeignKey(nameof(OwnerId))]
        public virtual IdentityUser Owner { get; set; } = null!;


        /// <summary>
        /// Gets or sets the Id of the species
        /// to which the pet belongs.
        /// </summary>

        [Comment("Species pet")]
        public int SpeciesId { get; set; }


        /// <summary>
        /// Gets or sets the species of the pet.
        /// </summary>
        [ForeignKey(nameof(SpeciesId))]
        public virtual Species Species { get; set; } = null!;


        /// <summary>
        /// Gets or sets the optional Id of the pet's breed.
        /// </summary>
        [Comment("Breed's specie")]
        public int? BreedId { get; set; }

        [ForeignKey(nameof(BreedId))]
        public virtual Breed? Breed { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether the pet
        /// has been soft-deleted.
        /// </summary>
        /// <remarks>
        /// Soft-deleted pets remain in the database
        /// but can be excluded from active pet queries.
        /// </remarks>
        [Comment("Indicates whether the pet has been soft-deleted")]
        public bool IsDeleted { get; set; } = false;



        /// <summary>
        /// Gets or sets the collection of appointments
        /// associated with the pet.
        /// </summary>
        public virtual ICollection<Appointment> Appointments { get; set; }
       = new List<Appointment>();


        /// <summary>
        /// Gets or sets the collection of medical records
        /// associated with the pet.
        /// </summary>
       public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
            = new HashSet<MedicalRecord>();
    }
}
