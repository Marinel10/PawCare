namespace PawCare.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PawCare.Services.Core.Contracts;
    using PawCare.Services.Data.Option;
    using PawCare.Services.Data.Pet.Request;
    using PawCare.Services.Data.Pet.Response;
    using PawCare.ViewModels.Breed;
    using PawCare.ViewModels.Pet;
    using PawCare.ViewModels.Species;
    using PawCare.Web.Controllers;
    using System.Security.Claims;
    using static PawCare.GCommon.Constants.ValidationConstants;

    [Authorize] 
    public class PetsController : BaseController
    {
        private readonly IPetService petService;
        private readonly ISpeciesService speciesService;
        private readonly IBreedService breedService;

        public PetsController(IPetService petService, ISpeciesService speciesService, IBreedService breedService)
        {
            this.petService = petService;
            this.speciesService = speciesService;
            this.breedService = breedService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Challenge();
            }

            IEnumerable<GetAllPetsResponseData> petsData =
                await petService.GetUserPetsAsync(userId);

            IEnumerable<PetViewModel> pets = petsData
                .Select(p => new PetViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    GenderName = p.GenderName,
                    PetImageUrl = p.PetImageUrl,
                    BirthDate = p.BirthDate,
                    OwnerId = p.OwnerId,
                    SpeciesName = p.SpeciesName,
                    BreedName = p.BreedName,
                    IsDeleted = p.IsDeleted
                })
                .ToArray();

            return View(pets);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            PetAddInputModel model = new PetAddInputModel()
            {
                Species = await SpeciesDropdownsAsync()
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> LoadBreeds(PetAddInputModel inputModel)
        {
            inputModel.BreedId = null;
            ModelState.Remove(nameof(inputModel.BreedId));

            inputModel.Species = await SpeciesDropdownsAsync();


            bool validSpecies = await speciesService.SpeciesExistsByIdAsync(inputModel.SpeciesId);

            if (validSpecies)
            {
                inputModel.Breeds =  await BreedDropdownsAsync(inputModel.SpeciesId);
            }
            else
            {
                inputModel.Breeds = [];
            }

            return View("Create", inputModel);
        }



        [HttpPost]
        public async Task<IActionResult> Create(PetAddInputModel inputModel)
        {
            
            
            if (!IsUserAuthenticated())
            {
                return Challenge();
            }

            string? userId = GetUserId();

            if (inputModel.BirthDate.HasValue && !ValidateBirthDate(inputModel.BirthDate))
            {
                ModelState.AddModelError(
                    nameof(inputModel.BirthDate),
                    "Enter a valid birth date.");
            }

            bool validSpecies = await speciesService.SpeciesExistsByIdAsync(inputModel.SpeciesId);

            if (!validSpecies || inputModel.SpeciesId <= 0)
            {
                ModelState.AddModelError(nameof(inputModel.SpeciesId), "Please select an existing species.");
            }


            if (validSpecies && (inputModel.BreedId > 0))
            {
                bool validBreed = await breedService.BelongsToSpeciesAsync(
                    inputModel.BreedId.Value,
                    inputModel.SpeciesId);

                if (!validBreed)
                {
                    ModelState.AddModelError(
                        nameof(inputModel.BreedId),
                        "This breed does not belong to the selected species.");
                }
            }


            if (!ModelState.IsValid)
            {
                inputModel.Species = await SpeciesDropdownsAsync();
                return View(inputModel);
            }



            AddPetRequestData request = new AddPetRequestData
            {
                Name = inputModel.Name,
                Gender = inputModel.Gender!,
                BirthDate = inputModel.BirthDate!.Value,
                PetImageUrl = inputModel.PetImageUrl,
                SpeciesId = inputModel.SpeciesId,
                BreedId = inputModel.BreedId,
                OwnerId = userId
            };

            bool isCreated = await petService.CreateAsync(request);

            if (!isCreated)
            {
                ModelState.AddModelError(string.Empty, "Unable to create pet. Please try again.");

                inputModel.Species = await SpeciesDropdownsAsync();
                inputModel.Breeds = await BreedDropdownsAsync(inputModel.SpeciesId);

                return View(inputModel);
            }

            return RedirectToAction(nameof(Index));
        }

    


        [HttpGet]
        public IActionResult Details(int id) => View();


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!IsUserAuthenticated())
            {
                return Challenge();
            }

            string? userId = GetUserId();

            GetPetForEditResponseData? pet =
                await petService.GetPetForEditAsync(id, userId);

            if (pet == null)
            {
                return NotFound();
            }

            EditPetInputModel model = new EditPetInputModel
            {
                Id = pet.Id,
                Name = pet.Name,
                Gender = pet.Gender,
                BirthDate = pet.BirthDate,
                PetImageUrl = pet.PetImageUrl,
                SpeciesId = pet.SpeciesId,
                BreedId = pet.BreedId,
                Species = await SpeciesDropdownsAsync(),
                Breeds = await BreedDropdownsAsync(pet.SpeciesId)
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditPetInputModel inputModel)
        {
            if (!IsUserAuthenticated())
            {
                return Challenge();
            }

            string? userId = GetUserId();

            if (inputModel.BirthDate.HasValue && !ValidateBirthDate(inputModel.BirthDate))
            {
                ModelState.AddModelError(
                    nameof(inputModel.BirthDate),
                    "Enter a valid birth date.");
            }

            bool validSpecies = inputModel.SpeciesId > 0 &&
                await speciesService.SpeciesExistsByIdAsync(inputModel.SpeciesId);

            if (!validSpecies)
            {
                ModelState.AddModelError(
                    nameof(inputModel.SpeciesId),
                    "Please select an existing species.");
            }

            if (validSpecies && inputModel.BreedId.HasValue &&
                !await breedService.BelongsToSpeciesAsync(
                    inputModel.BreedId.Value,
                    inputModel.SpeciesId))
            {
                ModelState.AddModelError(
                    nameof(inputModel.BreedId),
                    "This breed does not belong to the selected species.");
            }

            if (!ModelState.IsValid)
            {
                inputModel.Species = await SpeciesDropdownsAsync();

                inputModel.Breeds = validSpecies
                    ? await BreedDropdownsAsync(inputModel.SpeciesId)
                    : [];

                return View(inputModel);
            }

            EditPetRequestData request = new EditPetRequestData
            {
                Id = inputModel.Id,
                OwnerId = userId,
                Name = inputModel.Name,
                Gender = inputModel.Gender!,
                BirthDate = inputModel.BirthDate!.Value,
                PetImageUrl = inputModel.PetImageUrl,
                SpeciesId = inputModel.SpeciesId,
                BreedId = inputModel.BreedId
            };

            bool isEdited = await petService.EditAsync(request);

            if (!isEdited)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id) => View();



        private async Task<IEnumerable<SpeciesViewModel>> SpeciesDropdownsAsync()
        {

            IEnumerable<SpeciesOptionData> speciesOptionDatas = await speciesService.GetAllForDropdownAsync();

            IEnumerable<SpeciesViewModel> allSpecies = speciesOptionDatas
                .Select(s => new SpeciesViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToArray();


            return allSpecies;
        }
      
        private async Task<IEnumerable<BreedViewModel>> BreedDropdownsAsync(int speciesId)
        {


            IEnumerable<BreedOptionData> breedsOptionDatas = await breedService.BreedsGetBySpeciesIdAsync(speciesId);

            IEnumerable<BreedViewModel> allBreeds = breedsOptionDatas
                .Select(s => new BreedViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToArray();


            return allBreeds;
        }


        private bool ValidateBirthDate(DateTime? birthDate)
        {
            if (!birthDate.HasValue)
            {
                return false;
            }

            return birthDate.Value.Date <= DateTime.Today &&
                   birthDate.Value.Year >= Pet.MinBirthYear;
        }





    }
}
