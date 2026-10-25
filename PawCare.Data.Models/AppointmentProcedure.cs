
namespace PawCare.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents the relationship between an appointment
    /// and a veterinary procedure.
    /// </summary>
    [PrimaryKey(nameof(AppointmentId), nameof(ProcedureId))]
    public class AppointmentProcedure
    {
        /// <summary>
        /// Gets or sets the identifier of the appointment.
        /// </summary>
        [Comment("Foreign key to the appointment")]
        public int AppointmentId { get; set; }

        /// <summary>
        /// Gets or sets the appointment associated with the procedure.
        /// </summary>
        [ForeignKey(nameof(AppointmentId))]
        public virtual Appointment Appointment { get; set; } = null!;

        /// <summary>
        /// Gets or sets the identifier of the veterinary procedure.
        /// </summary>
        [Comment("Foreign key to the procedure")]
        public int ProcedureId { get; set; }

        /// <summary>
        /// Gets or sets the veterinary procedure associated
        /// with the appointment.
        /// </summary>
        [ForeignKey(nameof(ProcedureId))]
        public virtual Procedure Procedure { get; set; } = null!;
    }
}
