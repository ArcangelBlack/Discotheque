using DomainModels.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<AppCategorie>> GetAll();

        Task<AppCategorie> GetById(int id);

        Task<int> Create(AppCategorie dto);

        Task<int> Update(AppCategorie dto);

        Task<int> Delete(int id);
    }
}