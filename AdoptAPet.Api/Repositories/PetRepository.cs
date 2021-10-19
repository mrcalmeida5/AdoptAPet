using AdoptAPet.Api.Data;
using AdoptAPet.Domain.Interfaces;
using AdoptAPet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptAPet.Api.Repositories
{
    public class PetRepository : BaseRepository<Pet>, IPetRepository
    {
        public PetRepository(AppDbContext context) : base(context)
        {
        }

    }
}
