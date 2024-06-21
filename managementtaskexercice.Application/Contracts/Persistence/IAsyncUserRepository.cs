using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Persistence
{
    public  interface IAsyncUserRepository
    {
        public Task AddAsync(AppUser user);

    }
}
