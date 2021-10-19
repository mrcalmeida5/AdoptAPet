using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptAPet.Api.DTOs
{
    public class PetDtoOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PetTypeId { get; set; }
    }
}
