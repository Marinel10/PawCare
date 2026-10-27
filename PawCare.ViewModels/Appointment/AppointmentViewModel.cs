namespace PawCare.ViewModels.Appointment
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Reason { get; set; }
        public string Status { get; set; } = null!;
    }
}
