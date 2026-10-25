namespace PawCare.Data.Models
{

    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using PawCare.Data.Models.Enums;
    using static PawCare.GCommon.Constants.ValidationConstants.Appointment;


    /// <summary>
    /// Represents a scheduled veterinary appointment for a pet.
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Gets or sets the unique identifier of the appointment.
        /// </summary>
        
        [Key]
        [Comment("Unique identifier of the appointment")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Id of the pet appointment.
        /// </summary>
        [Comment("Foreign key to the pet")]
        public int PetId { get; set; }

        /// <summary>
        /// Gets or sets the pet  appointment.
        /// </summary>
        [ForeignKey(nameof(PetId))]
        public virtual Pet Pet { get; set; } = null!;


        /// <summary>
        /// Gets or sets the scheduled start date and time
        /// of the appointment.
        /// </summary>
        [Column(TypeName = AppointmentDateColumnType)]
        [Comment("Scheduled start date and time")]
        public DateTime StartTime { get; set; }


        /// <summary>
        /// Gets or sets the scheduled end date and time
        /// of the appointment.
        /// </summary>
        [Column(TypeName = AppointmentDateColumnType)]
        [Comment("Scheduled end date and time")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the date and time when
        /// the appointment was created.
        /// </summary>
        [Required]
        [Column(TypeName = AppointmentDateColumnType)]
        [Comment("Date and time when the appointment was created")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the optional reason for the appointment.
        /// </summary>
        [StringLength(ReasonMax)]
        [Comment("Reason for the veterinary appointment")]
        public string? Reason { get; set; }


        /// <summary>
        /// Gets or sets the current status of the appointment.
        /// </summary>
        [Comment("Current status of the appointment")]
        public AppointmentStatus Status { get; set; }


        /// <summary>
        /// Gets or sets the collection of Procedure
        /// associated with the appointment.
        /// </summary>
        public virtual ICollection<AppointmentProcedure> AppointmentProcedure { get; set; } 
            = new HashSet<AppointmentProcedure>();
    }
}
