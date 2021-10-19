﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptAPet.Api.DTOs
{
    public class PetTypeDtoOut
    {
        public int Id { get;set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
