using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawCare.ViewModels.Pet
{
    public class PetViewModel
    {
        public int Id { get; set; }


        public string Name { get; set; } = null!;

        public string GenderName { get; set; }

        public string? PetImageUrl { get; set; }


        public DateTime BirthDate { get; set; }

        public string OwnerId { get; set; } = null!;

        public string SpeciesName { get; set; } = null!;

        public string BreedName { get; set; }


        public bool IsDeleted { get; set; }
    }
}
