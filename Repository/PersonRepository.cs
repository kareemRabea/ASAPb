using ASAP.Data;
using ASAP.Interfaces;
using ASAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASAP.Repository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
         private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    
    }
}
