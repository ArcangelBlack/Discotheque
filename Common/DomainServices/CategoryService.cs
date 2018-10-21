using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Model;
using DomainModels.Repositories;
using DomainServices.Interfaces;

namespace DomainServices
{
    public class CategoryService : ICategoryService
    {
        public async Task<IEnumerable<AppCategorie>> GetAll()
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.CategoryRespository.GetAll();
            }
        }

        public async Task<AppCategorie> GetById(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.CategoryRespository.GetById(id);
            }
        }

        public async Task<int> Create(AppCategorie entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.CategoryRespository.Add(entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                var entity = await this.GetById(id);
                if(entity != null)
                {
                    return await rm.CategoryRespository.Delete(entity);
                }
                else
                {
                    return -1;
                }
            }
        }

        public async Task<int> Update(AppCategorie entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.CategoryRespository.Update(entity);
            }
        }
    }
}
