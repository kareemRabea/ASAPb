using ASAP.Data;
using ASAP.Interfaces;
using ASAP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IPersonRepository Person { get; private set; }
        public IAddressRepository Address { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Person = new PersonRepository(_context);
            Address = new AddressRepository(_context);
        }



        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
