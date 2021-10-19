using AdoptAPet.Api.Data;
using AdoptAPet.Domain.Interfaces;
using AdoptAPet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdoptAPet.Api.Repositories
{
    public class PetTypeRepository : BaseRepository<PetType>, IPetTypeRepository
    {
        public PetTypeRepository(AppDbContext context) : base(context)
        {
        }

    }
}
