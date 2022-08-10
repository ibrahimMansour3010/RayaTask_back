using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Repositories
{
    public interface IAddressRepo : IGenericRepo<Address>
    {
        Task AddRange(IEnumerable<Address> addresses);
        void DeleteRange(IEnumerable<Address> addresses);
    }
}
