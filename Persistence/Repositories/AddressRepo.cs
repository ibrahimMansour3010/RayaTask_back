using Application.Contracts.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AddressRepo:GenericRepo<Address>,IAddressRepo
    {
        private readonly RayaTaskDBContext _dBContext;
        public AddressRepo(RayaTaskDBContext dBContext):base(dBContext)
        {
            _dBContext = dBContext;
        }
        public void DeleteRange(IEnumerable<Address> addresses)
        {
            _dBContext.RemoveRange(addresses);
        }
        public async Task AddRange(IEnumerable<Address> addresses)
        {
           await _dBContext.AddRangeAsync(addresses);
        }
    }
}
