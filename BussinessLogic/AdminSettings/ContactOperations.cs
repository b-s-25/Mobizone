using DomainLayer.AdminSettings;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.AdminSettings
{
    public class ContactOperations: IContactOperations
    {
        IGenericRepositoryOperation<Contact> _repo;
        public ContactOperations(IGenericRepositoryOperation<Contact> repo)
        {
            _repo = repo;
        }
        public async Task Add(Contact data)
        {
            _repo.Add(data);
            _repo.Save();

        }

        public async Task Edit(Contact data)
        {
            _repo.Update(data);
            _repo.Save();
        }

        public async Task Get(Contact data)
        {
            _repo.GetAll();
        }

        public IEnumerable<Contact> Get()
        {

            return _repo.GetAll();
        }
    }
}
