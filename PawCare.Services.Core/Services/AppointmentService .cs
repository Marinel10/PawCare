
namespace PawCare.Services.Core.Services
{
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using PawCare.Data;
    using PawCare.Data.Models;
    using PawCare.Data.Models.Enums;
    using PawCare.Services.Data.Appointment.Request;
    using PawCare.Services.Data.Appointment.Response;
    using System.Collections.Generic;

    public class AppointmentService : IAppointmentService
    {
        private readonly PawCareDbContext dbContext;

        public AppointmentService(PawCareDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetAllAppointmentsResponseData>>GetUserAppointmentsAsync(string userId)
        {
            IEnumerable<GetAllAppointmentsResponseData> appointments =
                await dbContext.Appointments
                    .AsNoTracking()
                    .Where(a => a.Pet.OwnerId == userId)
                    .Select(a => new GetAllAppointmentsResponseData()
                    {
                        Id = a.Id,
                        PetId = a.PetId,
                        PetName = a.Pet.Name,
                        StartTime = a.StartTime,
                        EndTime = a.EndTime,
                        Reason = a.Reason,
                        Status = a.Status.ToString()
                    })
                    .ToArrayAsync();

            return appointments;
        }

        public async Task<GetAppointmentDetailsResponseData?> GetAppointmentDetailsAsync(int appointmentId, string userId)
        {
            GetAppointmentDetailsResponseData? appointmentData =
                await dbContext.Appointments
                    .AsNoTracking()
                    .Where(a => a.Id == appointmentId &&
                                a.Pet.OwnerId == userId)
                    .Select(a => new GetAppointmentDetailsResponseData()
                    {
                        Id = a.Id,
                        PetId = a.PetId,
                        PetName = a.Pet.Name,
                        StartTime = a.StartTime,
                        EndTime = a.EndTime,
                        CreatedOn = a.CreatedOn,
                        Reason = a.Reason,
                        Status = a.Status.ToString()
                    })
                    .FirstOrDefaultAsync();

            return appointmentData;
        }

        public async Task<GetAppointmentForEditResponseData?>GetAppointmentForEditAsync(int appointmentId, string userId)
        {
            GetAppointmentForEditResponseData? appointmentData =
                await dbContext.Appointments
                    .AsNoTracking()
                    .Where(a => a.Id == appointmentId &&
                                a.Pet.OwnerId == userId &&
                                !a.Pet.IsDeleted &&
                                a.Status != AppointmentStatus.Cancelled &&
                                a.Status != AppointmentStatus.Completed)
                    .Select(a => new GetAppointmentForEditResponseData()
                    {
                        Id = a.Id,
                        PetId = a.PetId,
                        StartTime = a.StartTime,
                        EndTime = a.EndTime,
                        Reason = a.Reason
                    })
                    .FirstOrDefaultAsync();

            return appointmentData;
        }

        public async Task<bool> CreateAsync(AddAppointmentRequestData request)
        {
            bool petExists = await dbContext.Pets
                .AnyAsync(p => p.Id == request.PetId &&
                               p.OwnerId == request.OwnerId && !p.IsDeleted);

            if (!petExists)
            {
                return false;
            }

            if (request.StartTime <= DateTime.Now ||
                request.EndTime <= request.StartTime)
            {
                return false;
            }

            Appointment newAppointment = new Appointment()
            {
                PetId = request.PetId,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                CreatedOn = DateTime.Now,
                Reason = request.Reason?.Trim(),
                Status = AppointmentStatus.Confirmed
            };

            try
            {
                await dbContext.Appointments.AddAsync(newAppointment);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public async Task<bool> EditAsync(EditAppointmentRequestData request)
        {
            Appointment? appointment = await dbContext.Appointments
                .FirstOrDefaultAsync(a =>
                    a.Id == request.Id &&
                    a.Pet.OwnerId == request.OwnerId && !a.Pet.IsDeleted &&
                    a.Status != AppointmentStatus.Cancelled &&
                    a.Status != AppointmentStatus.Completed);

            if (appointment == null)
            {
                return false;
            }

            bool petExists = await dbContext.Pets
                .AnyAsync(p => p.Id == request.PetId &&
                               p.OwnerId == request.OwnerId &&
                               !p.IsDeleted);

            if (!petExists)
            {
                return false;
            }

            if (request.StartTime <= DateTime.Now ||
                request.EndTime <= request.StartTime)
            {
                return false;
            }

            appointment.PetId = request.PetId;
            appointment.StartTime = request.StartTime;
            appointment.EndTime = request.EndTime;
            appointment.Reason = request.Reason?.Trim();

            try
            {
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> CancelAsync(int appointmentId, string userId)
        {
            Appointment? appointment = await dbContext.Appointments
                .FirstOrDefaultAsync(a =>
                    a.Id == appointmentId &&
                    a.Pet.OwnerId == userId &&
                    !a.Pet.IsDeleted &&
                    a.Status != AppointmentStatus.Cancelled &&
                    a.Status != AppointmentStatus.Completed);

            if (appointment == null)
            {
                return false;
            }

            appointment.Status = AppointmentStatus.Cancelled;

            try
            {
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
