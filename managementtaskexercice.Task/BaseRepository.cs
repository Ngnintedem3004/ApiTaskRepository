using managementtaskexercice.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Task
{
    public  class BaseRepository
    {
        protected readonly ManagementtaskDbContext _context;
        public BaseRepository(ManagementtaskDbContext context)
        {
            _context = context;
        }
    }
}
