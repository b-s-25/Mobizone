using DomainLayer;
using Repository;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Orders.Admin
{
<<<<<<< HEAD
    public class OrderDetailsOperations: GenericRepositoryOperation<UserCheckOut>,IOrderDetailsOperations
=======

    public class OrderDetailsOperations: GenericRepositoryOperation<UserCheckOut>,IOrderDetailsOperations

>>>>>>> ae3e2d92446c463247c65daf230ae3d0c294e19b
    {
        private readonly IGenericRepositoryOperation<UserCheckOut> _repo;
        private readonly ProductDbContext _dbContext;
        public OrderDetailsOperations(ProductDbContext dbContext, IGenericRepositoryOperation<UserCheckOut> repo) :base(dbContext)
        {
            _repo = repo;
            _dbContext = dbContext;

        }
        public async Task<IEnumerable<UserCheckOut>> GetAll()
        {
<<<<<<< HEAD
            return await _repo.GetAll(x => x.user, x => x.product);
=======

         
            return await _repo.GetAll(x => x.user, x => x.product, x => x.address);

>>>>>>> ae3e2d92446c463247c65daf230ae3d0c294e19b
        }
        public async Task Add(UserCheckOut data)
        {
            try
            {
                _repo.Add(data);
                _repo.Save();
            }
            catch (Exception ex)
            {

            }
        }
        public async Task Edit(UserCheckOut entity)
        {
            _repo.Update(entity);
            _repo.Save();
        }
        public async Task Delete(UserCheckOut entity)
        {
            _repo.Delete(entity);
            _repo.Save();
        }

       
    }
}
