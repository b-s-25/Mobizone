using RepositoryLayer.Interface;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace BussinessLogic
{
   public  class UserDataoperation: IUserDataoperation
    {
        private readonly IGenericRepositoryOperation<Registration> _repo;
        private readonly ProductDbContext _dbContext;
        public UserDataoperation( ProductDbContext dbContext)
        {
            _dbContext = dbContext;
            _repo = new GenericRepositoryOperation<Registration>(_dbContext);

        }
        public IEnumerable<Registration> GetUserData()
        {
            return _repo.GetAll();
        }
    }
}
