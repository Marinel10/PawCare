

namespace PawCare.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;

    using static PawCare.GCommon.Constants.ValidationConstants.Procedure;

    /// <summary>
    /// Represents a veterinary procedure offered by the clinic.
    /// </summary>
    public class Procedure
    {
        /// <summary>
        /// Gets or sets the unique identifier of the procedure.
        /// </summary>
        [Key]
        [Comment("Unique identifier of the procedure")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the veterinary procedure.
        /// </summary>
        [Required]
        [StringLength(NameMax, MinimumLength = NameMin)]
        [Comment("Name of the veterinary procedure")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the description of the procedure.
        /// </summary>
        [StringLength(DescriptionMax)]
        [Comment("Description of the veterinary procedure")]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the veterinary procedure.
        /// </summary>
        [Precision(18, 2)]
        [Comment("Price of the veterinary procedure")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the appointments associated with this procedure.
        /// </summary>
        public virtual ICollection<AppointmentProcedure> AppointmentProcedures { get; set; }
                = new HashSet<AppointmentProcedure>();
    }
}
