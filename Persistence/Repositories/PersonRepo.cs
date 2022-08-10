using Application.Contracts.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PersonRepo:GenericRepo<Person>, IPersonRepo
    {
        private readonly RayaTaskDBContext _dbContext;
        public PersonRepo(RayaTaskDBContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
