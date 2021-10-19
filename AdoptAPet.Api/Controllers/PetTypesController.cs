using AdoptAPet.Api.Data;
using AdoptAPet.Api.DTOs;
using AdoptAPet.Domain.Interfaces;
using AdoptAPet.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptAPet.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PetTypesController : Controller
    {
        private readonly IPetTypeRepository _pettypes;

        public PetTypesController(IPetTypeRepository pettypes)
        {
            _pettypes = pettypes;
        }

        [HttpGet]
        public async Task<IActionResult> GetPetTypesAsync()
        {
            var types = await _pettypes.GetAllAsync();

            if (types == null)
                return NotFound();

            var result = new List<PetTypeDtoOut>();
            for(int i = 0; i < types.Count(); i++)
            {
                var typeDto = new PetTypeDtoOut();
                typeDto.Description = types.ElementAt(i).Description;
                typeDto.Id = types.ElementAt(i).Id;
                typeDto.Title = types.ElementAt(i).Title;
                result.Add(typeDto);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPetTypeByIdAsync([FromRoute] int id)
        {
            var type = await _pettypes.GetByIdAsync(id);
            if (type == null)
                return NotFound();

            var result = new PetTypeDtoOut();
            result.Description = type.Description;
            result.Id = type.Id;
            result.Title = type.Title;

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePetTypeAsync([FromBody] PetTypeDtoIn model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                PetType type = new PetType
                { 
                    Title = model.Title,
                    Description = model.Description
                };

                var result = await _pettypes.CreateAsync(type);
                if (result == null)
                    return BadRequest("Pet type wasn't added. Try again.");

                var resultOut = new PetTypeDtoOut();
                resultOut.Description = type.Description;
                resultOut.Id = type.Id;
                resultOut.Title = type.Title;

                return Created($"/api/pettypes/{resultOut.Id}", resultOut);

            }
            catch
            {
                return BadRequest("Pet wasn't added. Try again.");
            }
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePetType([FromBody] PetTypeDtoIn updatedTypeDtoIn, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var updatedType = new PetType();
            updatedType.Id = id;
            updatedType.Description = updatedTypeDtoIn.Description;
            updatedType.Title = updatedTypeDtoIn.Title;

            var result = await _pettypes.UpdateAsync(updatedType);
            if (!result)
                return BadRequest("Couldn't updated pet type. Please try again.");

            return Ok("Pet type was updated successfully.");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePetTypeAsync(int id)
        {
            bool result = await _pettypes.DeleteAsync(id);
            if (!result)
                return BadRequest("Can't delete pet type. Try again later!");

            return Ok("Pet type was deleted!");
        }
    }
}
