using Application.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RayaTaskDBContext _context;
        private  IPersonRepo _personRepo;
        private  IAddressRepo _addressRepo;

        public UnitOfWork(RayaTaskDBContext context)
        {
            _context = context;
        }
        public IPersonRepo PersonRepo => _personRepo ??= new PersonRepo(_context);
        public IAddressRepo AddressRepo => _addressRepo ??= new AddressRepo(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
