namespace PawCare.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using PawCare.Services.Core.Contracts;
    using PawCare.Services.Data.Appointment.Request;
    using PawCare.Services.Data.Appointment.Response;
    using PawCare.Services.Data.Pet.Response;
    using PawCare.ViewModels.Appointment;
    using PawCare.ViewModels.Pet;
    using PawCare.Web.Controllers;

    [Authorize]
    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentService appointmentService;
        private readonly IPetService petService;

        public AppointmentsController(IAppointmentService appointmentService, IPetService petService)
        {
            this.appointmentService = appointmentService;
            this.petService = petService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            IEnumerable<GetAllAppointmentsResponseData> appointmentsData =
                await appointmentService.GetUserAppointmentsAsync(userId);

            IEnumerable<AppointmentViewModel> appointments = appointmentsData
                .Select(a => new AppointmentViewModel()
                {
                    Id = a.Id,
                    PetId = a.PetId,
                    PetName = a.PetName,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    Reason = a.Reason,
                    Status = a.Status
                })
                .ToArray();

            return View(appointments);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            GetAppointmentDetailsResponseData? appointmentData =
                await appointmentService.GetAppointmentDetailsAsync(id, userId);

            if (appointmentData == null)
            {
                return NotFound();
            }


            AppointmentDetailsViewModel model = new AppointmentDetailsViewModel()
            {
                Id = appointmentData.Id,
                PetId = appointmentData.PetId,
                PetName = appointmentData.PetName,
                StartTime = appointmentData.StartTime,
                EndTime = appointmentData.EndTime,
                CreatedOn = appointmentData.CreatedOn,
                Reason = appointmentData.Reason,
                Status = appointmentData.Status
            };

            if (model.Status == "Cancelled")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            AppointmentCreateInputModel model = new AppointmentCreateInputModel()
            {
                Pets = await PetDropdownsAsync(userId)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentCreateInputModel inputModel)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            ValidateTimes(inputModel.StartTime, inputModel.EndTime);

            if (!ModelState.IsValid)
            {
                inputModel.Pets = await PetDropdownsAsync(userId);
                return View(inputModel);
            }

            AddAppointmentRequestData request = new AddAppointmentRequestData()
            {
                OwnerId = userId,
                PetId = inputModel.PetId,
                StartTime = inputModel.StartTime!.Value,
                EndTime = inputModel.EndTime!.Value,
                Reason = inputModel.Reason
            };

            bool isCreated = await appointmentService.CreateAsync(request);
            if (!isCreated)
            {
                ModelState.AddModelError(string.Empty, "Unable to book appointment. Check the selected pet and dates.");
                inputModel.Pets = await PetDropdownsAsync(userId);
                return View(inputModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            GetAppointmentForEditResponseData? appointmentData =
                await appointmentService.GetAppointmentForEditAsync(id, userId);

            if (appointmentData == null)
            {
                return NotFound();
            }

            AppointmentEditInputModel model = new AppointmentEditInputModel()
            {
                Id = appointmentData.Id,
                PetId = appointmentData.PetId,
                StartTime = appointmentData.StartTime,
                EndTime = appointmentData.EndTime,
                Reason = appointmentData.Reason,
                Pets = await PetDropdownsAsync(userId)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AppointmentEditInputModel inputModel)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            if (id != inputModel.Id)
            {
                return BadRequest();
            }

            ValidateTimes(inputModel.StartTime, inputModel.EndTime);

            if (!ModelState.IsValid)
            {
                inputModel.Pets = await PetDropdownsAsync(userId);
                return View(inputModel);
            }

            EditAppointmentRequestData request = new EditAppointmentRequestData()
            {
                Id = id,
                OwnerId = userId,
                PetId = inputModel.PetId,
                StartTime = inputModel.StartTime!.Value,
                EndTime = inputModel.EndTime!.Value,
                Reason = inputModel.Reason
            };

            bool isEdited = await appointmentService.EditAsync(request);
            if (!isEdited)
            {
                ModelState.AddModelError(string.Empty, "Unable to edit appointment. Check ownership, status and dates.");
                inputModel.Pets = await PetDropdownsAsync(userId);
                return View(inputModel);
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            bool isCancelled = await appointmentService.CancelAsync(id, userId);
            if (!isCancelled)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<PetViewModel>> PetDropdownsAsync(string userId)
        {
            IEnumerable<GetAllPetsResponseData> petsData =
                await petService.GetUserPetsAsync(userId);

            IEnumerable<PetViewModel> pets = petsData
                .Select(p => new PetViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToArray();

            return pets;
        }

        private void ValidateTimes(DateTime? startTime, DateTime? endTime)
        {
            if (startTime.HasValue && startTime.Value <= DateTime.Now)
            {
                ModelState.AddModelError(nameof(AppointmentCreateInputModel.StartTime),
                    "Start time must be in the future.");
            }

            if (startTime.HasValue && endTime.HasValue && endTime.Value <= startTime.Value)
            {
                ModelState.AddModelError(nameof(AppointmentCreateInputModel.EndTime),
                    "End time must be later than start time.");
            }
        }
    }
}
