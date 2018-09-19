using DomainModels.Model;
using DomainModels.Repositories;
using DomainServices.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices
{
    public class CompanyService : ICompanyService
    {
        public async Task<IEnumerable<AppCompanie>> GetAll()
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.CompanieRepository.GetAll();
            }
        }
    }
}
