using System;
using System.Collections.Generic;
using System.Text;

namespace AdoptAPet.Domain.Models
{
    public class PetType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Pet> Pets { get; set; }

    }
}
