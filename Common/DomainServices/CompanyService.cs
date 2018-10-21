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

        public async Task<AppCompanie> GetById(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.CompanieRepository.GetById(id);
            }
        }

        public async Task<int> Create(AppCompanie entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.CompanieRepository.Add(entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                var entity = await this.GetById(id);
                if (entity != null)
                {
                    return await rm.CompanieRepository.Delete(entity);
                }
                return 0;
            }
        }

        public async Task<int> Update(AppCompanie entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.CompanieRepository.Update(entity);
            }
        }
    }
}
