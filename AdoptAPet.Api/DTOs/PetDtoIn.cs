using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptAPet.Api.DTOs
{
    public class PetDtoIn
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int PetTypeId { get; set; }
    }
}
