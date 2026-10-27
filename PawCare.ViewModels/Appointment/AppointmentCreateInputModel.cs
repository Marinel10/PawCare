namespace PawCare.ViewModels.Appointment
{
    using PawCare.ViewModels.Pet;
    using System.ComponentModel.DataAnnotations;

    public class AppointmentCreateInputModel
    {
        public int PetId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? StartTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? EndTime { get; set; }

        public string? Reason { get; set; }

        public IEnumerable<PetViewModel> Pets { get; set; } = new List<PetViewModel>();
    }
}
