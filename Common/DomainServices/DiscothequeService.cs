using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Model;
using DomainModels.Repositories;
using DomainServices.Interfaces;

namespace DomainServices
{
    public class DiscothequeService : IDiscothequeService
    {
        public async Task<IEnumerable<AppDiscotheque>> GetAll()
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.DiscothequeRepository.GetAll();
            }
        }

        public async Task<AppDiscotheque> GetById(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.DiscothequeRepository.GetById(id);
            }
        }

        public async Task<int> Create(AppDiscotheque entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.DiscothequeRepository.Add(entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                var entity = await this.GetById(id);
                if (entity != null)
                {
                    return await rm.DiscothequeRepository.Delete(entity);
                }
                return -1;
            }
        }

        public async Task<int> Update(AppDiscotheque entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.DiscothequeRepository.Update(entity);
            }
        }
    }
}
