

namespace PawCare.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    using static PawCare.GCommon.Constants.ValidationConstants.MedicalRecord;

    /// <summary>
    /// Represents a medical record containing information
    /// about a pet's diagnosis and treatment.
    /// </summary>
    public class MedicalRecord
    {
        /// <summary>
        /// Gets or sets the unique identifier of the medical record.
        /// </summary>
        [Key]
        [Comment("Unique identifier of the medical record")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the pet.
        /// </summary>
        [Comment("Foreign key to the pet")]
        public int PetId { get; set; }

        /// <summary>
        /// Gets or sets the pet associated with the medical record.
        /// </summary>
        [ForeignKey(nameof(PetId))]
        public virtual Pet Pet { get; set; } = null!;

        /// <summary>
        /// Gets or sets the optional appointment identifier.
        /// </summary>
        [Comment("Optional foreign key to the appointment")]
        public int? AppointmentId { get; set; }

        /// <summary>
        /// Gets or sets the appointment associated with the medical record.
        /// </summary>
        [ForeignKey(nameof(AppointmentId))]
        public virtual Appointment? Appointment { get; set; }

        /// <summary>
        /// Gets or sets the diagnosis made by the veterinarian.
        /// </summary>
        [Required]
        [StringLength(DiagnosisMax)]
        [Comment("Diagnosis recorded by the veterinarian")]
        public string Diagnosis { get; set; } = null!;

        /// <summary>
        /// Gets or sets the treatment prescribed for the pet.
        /// </summary>
        [StringLength(TreatmentMax)]
        [Comment("Treatment prescribed for the pet")]
        public string? Treatment { get; set; }

        /// <summary>
        /// Gets or sets additional medical notes.
        /// </summary>
        [StringLength(NotesMax)]
        [Comment("Additional notes about the pet's health")]
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the record was created.
        /// </summary>       
        [Column(TypeName = MedicalRecordDateColumnType)]
        [Comment("Date and time when the medical record was created")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
