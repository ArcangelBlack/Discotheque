using D.Models;
using D.Models.Models;
using DiscothequeW.Services.Interaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscothequeW.Services
{
    public class DiscothequeService : IDiscothequeService
    {
        public Task<IEnumerable<Discotheque>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Discotheque>> GetAllByCompanyId(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<Discotheque> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Discotheque entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Discotheque entity)
        {
            throw new NotImplementedException();
        }

        public Task<Discotheque> Update(Discotheque entity)
        {
            throw new NotImplementedException();
        }
    }
}
