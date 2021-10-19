using AdoptAPet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptAPet.Api.Interfaces
{
    public interface ISeederService
    {
        List<Pet> GetPets();
        bool AddPet(Pet pet);
        bool UpdatePet(Pet updatedPet);
        bool DeletePet(int id);
    }
}
