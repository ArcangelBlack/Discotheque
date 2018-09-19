using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Model;
using DomainModels.Repositories;
using DomainServices.Interfaces;

namespace DomainServices
{
    public class CategoryService : ICategoryService
    {
        public async Task<IEnumerable<AppDiscothequeCategorie>> GetAll()
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.DiscothequeCategoryRespository.GetAll();
            }
        }
    }
}
