namespace PawCare.Services.Core.Contracts
{

    using PawCare.Services.Data.Appointment.Request;
    using PawCare.Services.Data.Appointment.Response;

    public interface IAppointmentService
    {
        Task<IEnumerable<GetAllAppointmentsResponseData>> GetUserAppointmentsAsync(string userId);

        Task<GetAppointmentDetailsResponseData?> GetAppointmentDetailsAsync(int appointmentId, string userId);

        Task<GetAppointmentForEditResponseData?> GetAppointmentForEditAsync(int appointmentId, string userId);

        Task<bool> CreateAsync(AddAppointmentRequestData request);

        Task<bool> EditAsync(EditAppointmentRequestData request);

        Task<bool> CancelAsync(int appointmentId, string userId);
    }
}
