using System;
using System.Collections.Generic;
using System.Text;

namespace AdoptAPet.Domain.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PetTypeId { get; set; }
        public PetType PetType { get; set; }
    }
}
