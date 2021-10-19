using AdoptAPet.Api.Data;
using AdoptAPet.Api.Interfaces;
using AdoptAPet.Api.DTOs;
using AdoptAPet.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptAPet.Domain.Interfaces;

namespace AdoptAPet.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PetsController : Controller
    {
        private readonly IPetRepository _pets;

        public PetsController(IPetRepository pets)
        {
            _pets = pets;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetPetsAsync()
        {
            var pets = await _pets.GetAllAsync();

            var result = new List<PetDtoOut>();
            for (int i = 0; i < pets.Count(); i++)
            {
                PetDtoOut pOut = new PetDtoOut();
                pOut.Id = pets.ElementAt(i).Id;
                pOut.Name = pets.ElementAt(i).Name;
                pOut.PetTypeId = pets.ElementAt(i).PetTypeId;

                result.Add(pOut);
            }

            return Ok(result);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPetByIdAsync([FromRoute] int id)
        {
            var pet = await _pets.GetByIdAsync(id);

            if (pet == null)
                return NotFound();

            PetDtoOut result = new PetDtoOut();
            result.Id = pet.Id;
            result.Name = pet.Name;
            result.PetTypeId = pet.PetTypeId;

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreatePetAsync([FromBody] PetDtoIn model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                Pet pet = new Pet
                {
                    Name = model.Name,
                    PetTypeId = model.PetTypeId,
                };

                var result = await _pets.CreateAsync(pet);
                if (result == null)
                    return BadRequest("Pet wasn't added. Try again.");

                var resultOut = new PetDtoOut();
                resultOut.Id = result.Id;
                resultOut.Name = result.Name;
                resultOut.PetTypeId = result.PetTypeId;

                return Created($"/api/pets/{resultOut.Id}", resultOut);

            }
            catch
            {
                return BadRequest("Pet wasn't added. Try again.");
            }
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePetAsync([FromBody] PetDtoIn updatedPetDtoIn, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var updatedPet = new Pet();
            updatedPet.Id = id;
            updatedPet.Name = updatedPetDtoIn.Name;
            updatedPet.PetTypeId = updatedPetDtoIn.PetTypeId;

            var result = await _pets.UpdateAsync(updatedPet);
            if (!result)
                return BadRequest("Couldn't updated pet. Please try again.");

            return Ok("Pet was updated successfully.");
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePetAsync(int id)
        {
            var result = await _pets.DeleteAsync(id);
            if (!result)
                return BadRequest("Can't delete pet. Try again later!");

            return Ok("Pet was deleted!");

        }
    }
}
