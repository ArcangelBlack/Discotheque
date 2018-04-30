using D.Models;
using D.Models.Models;
using DiscothequeW.Services.Interaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscothequeW.Services
{
    public class CompanyService : ICompanyService
    {
        public Task<IEnumerable<Company>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAllByCategories(IEnumerable<int> categories)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task<Company> Update(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
