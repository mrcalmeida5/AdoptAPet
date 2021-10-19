using System;
using System.Collections.Generic;
using System.Text;

namespace AdoptAPet.Domain.Models
{
    public class AdoptingCart
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
