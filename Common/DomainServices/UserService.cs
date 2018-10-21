using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Model;
using DomainModels.Repositories;
using DomainServices.Interfaces;

namespace DomainServices
{
    public class UserService : IUserService
    {
        public async Task<IEnumerable<AppUser>> GetAll()
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.UserRespository.GetAll();
            }
        }

        public async Task<AppUser> GetById(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.UserRespository.GetById(id);
            }
        }
        public async Task<int> Create(AppUser entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.UserRespository.Add(entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                var entity = await this.GetById(id);
                if(entity != null)
                {
                    return await rm.UserRespository.Delete(entity);
                }
                return -1;
            }
        }

        public async Task<int> Update(AppUser entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.UserRespository.Update(entity);
            }
        }
    }
}
