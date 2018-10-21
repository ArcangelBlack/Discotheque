using DomainModels.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Interfaces
{
    public interface IMusicService
    {
        Task<IEnumerable<AppMusic>> GetAll();

        Task<AppMusic> GetById(int id);

        Task<int> Create(AppMusic entity);

        Task<int> Update(AppMusic entity);

        Task<int> Delete(int id);
    }
}
