
namespace PawCare.Services.Data.Appointment.Request
{
    public class EditAppointmentRequestData
    {
        public int Id { get; set; }

        public string OwnerId { get; set; } = null!;

        public int PetId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string? Reason { get; set; }
    }
}
