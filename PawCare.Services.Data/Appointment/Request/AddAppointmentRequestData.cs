

namespace PawCare.Services.Data.Appointment.Request
{
    public class AddAppointmentRequestData
    {
        public int PetId { get; set; }

        public string OwnerId { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string? Reason { get; set; }
    }
}
