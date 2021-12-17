using ASAP.Interfaces;
using ASAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.UnitOfWork
{
     public interface IUnitOfWork:IDisposable
    {
        IPersonRepository Person { get; }
        IAddressRepository Address { get; }
        int Complete();
    }
}
