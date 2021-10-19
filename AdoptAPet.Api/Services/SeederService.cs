using AdoptAPet.Api.Interfaces;
using AdoptAPet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptAPet.Api.Services
{
    public class SeederService : ISeederService
    {
        private List<Pet> _pets = new List<Pet>();

        public SeederService()
        {
            var pet1 = new Pet
            {
                Id = 1,
                Name = "Black cat",
                PetType = new PetType
                {
                    Id = 1,
                    Title = "Cats",
                    Description = "Animal with 4 paws"
                }
            };
            _pets.Add(pet1);

            var pet2 = new Pet
            {
                Id = 2,
                Name = "White Dog",
                PetType = new PetType
                {
                    Id = 2,
                    Title = "Dogs",
                    Description = "Animal with 4 paws"
                }
            };
            _pets.Add(pet2);
        }

        public List<Pet> GetPets()
        {
            return _pets;
        }

        public bool AddPet(Pet pet)
        {
            _pets.Add(pet);
            return true;
        }

        public bool UpdatePet(Pet updatedPet)
        {
            if (updatedPet == null)
                return false;

            var pet = _pets.FirstOrDefault(x => x.Id == updatedPet.Id);
            if (pet == null)
                return false;

            _pets.Remove(pet);
            _pets.Add(updatedPet);

            return true;
        }

        public bool DeletePet(int id)
        {
            var pet = _pets.FirstOrDefault(x => x.Id == id);

            if (pet == null)
                return false;

            _pets.Remove(pet);
            return true;
        }
    }
}
