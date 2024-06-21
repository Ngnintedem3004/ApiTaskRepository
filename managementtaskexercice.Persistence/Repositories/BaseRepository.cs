using managementtaskexercice.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Persistence.Repositories
{
    public class BaseRepository
    {

        protected readonly ManagementtaskDbContext _context;
        public BaseRepository(ManagementtaskDbContext context ) {
            _context = context;
        }
        
    }
}
