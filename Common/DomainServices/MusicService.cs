using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Model;
using DomainModels.Repositories;
using DomainServices.Interfaces;

namespace DomainServices
{
    public class MusicService : IMusicService
    {
        public async Task<IEnumerable<AppMusic>> GetAll()
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.MusicRespository.GetAll();
            }
        }

        public async Task<AppMusic> GetById(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.MusicRespository.GetById(id);
            }
        }

        public async Task<int> Update(AppMusic entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.MusicRespository.Update(entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                var entity = await this.GetById(id);
                if (entity != null)
                {
                    return await rm.MusicRespository.Delete(entity);
                }
                return -1;
            }
        }

        public async Task<int> Create(AppMusic entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.MusicRespository.Add(entity);
            }
        }
    }
}
