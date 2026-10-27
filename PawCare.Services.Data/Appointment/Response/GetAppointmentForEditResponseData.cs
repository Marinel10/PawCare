
namespace PawCare.Services.Data.Appointment.Response
{
    public class GetAppointmentForEditResponseData
    {
        public int Id { get; set; }

        public int PetId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string? Reason { get; set; }
    }
}
