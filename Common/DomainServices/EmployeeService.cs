using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Model;
using DomainModels.Repositories;
using DomainServices.Interfaces;

namespace DomainServices
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<IEnumerable<AppEmployee>> GetAll()
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.EmployeeRespository.GetAll();
            }
        }

        public async Task<AppEmployee> GetById(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.EmployeeRespository.GetById(id);
            }
        }

        public async Task<int> Create(AppEmployee entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.EmployeeRespository.Update(entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                var entity = await this.GetById(id);
                if(entity != null) {
                    return await rm.EmployeeRespository.Delete(entity);
                }
                return -1;
            }
        }

        public async Task<int> Update(AppEmployee entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.EmployeeRespository.Update(entity);
            }
        }
    }
}
