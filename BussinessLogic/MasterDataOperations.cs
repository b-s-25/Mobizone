using DomainLayer;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
  public  class MasterDataOperations: IMasterDataOperations
    {
        private readonly IGenericRepositoryOperation<MasterData> _repo;
        private readonly ProductDbContext _dbContext;

        public MasterDataOperations(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
            _repo = new GenericRepositoryOperation<MasterData>(_dbContext);
        }
        public async Task MasterDataAdd(MasterData data)
        {
            _repo.Add(data);
            _repo.Save();
        }

        public async Task MasterDataDelete(MasterData entity)
        {
              _repo.Delete(entity);
            _repo.Save();
        }

        public IEnumerable<MasterData> GetAllMasterData()
        {
            return _repo.GetAll();
        }

        public async Task MasterDataEdit(MasterData entity)
        {
            _repo.Update(entity);
            _repo.Save();
        }

        public MasterData MasterDataGetById(int Id)
        {
            return _repo.GetById(Id);
        }

        Task<IEnumerable<MasterData>> IMasterDataOperations.GetAllMasterData()
        {
            throw new NotImplementedException();
        }
    }


}
