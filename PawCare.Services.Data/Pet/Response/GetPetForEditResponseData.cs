using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawCare.Services.Data.Pet.Response
{
    public class GetPetForEditResponseData
    {
        public int Id { get; set; }


        public string Name { get; set; } = null!;

        public int Gender { get; set; }

        public string? PetImageUrl { get; set; }


        public DateTime BirthDate { get; set; }

        public string OwnerId { get; set; } = null!;

        public int SpeciesId { get; set; }

        public int? BreedId { get; set; }


    }
}
