namespace PawCare.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static PawCare.GCommon.Constants.ValidationConstants.Species;


    /// <summary>
    /// Represents an animal species in the veterinary clinic.
    /// </summary>
    public class Species
    {
        /// <summary>
        /// Gets or sets the unique identifier of the species.
        /// </summary>
        [Key]
        [Comment("Primary key")]
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets the name of the species.
        /// </summary>
        [Required]
        [StringLength(NameMax,MinimumLength = NameMin)]
        [Comment("Name of the species")]
        public string Name { get; set; } = null!;


        /// <summary>
        /// Gets or sets the collection of breeds belonging to this species.
        /// </summary>
       // public virtual ICollection<Breed> Breeds { get; set; }
          //  = new HashSet<Breed>();


        /// <summary>
        /// Gets or sets the collection of pets belonging to this species.
        /// </summary>
       //public virtual ICollection<Pet> Pets { get; set; }
          //  = new HashSet<Pet>();

    }
}
