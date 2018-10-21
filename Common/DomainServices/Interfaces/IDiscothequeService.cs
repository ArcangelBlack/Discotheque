using DomainModels.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Interfaces
{
    public interface IDiscothequeService
    {
        Task<IEnumerable<AppDiscotheque>> GetAll();

        Task<AppDiscotheque> GetById(int id);

        Task<int> Create(AppDiscotheque entity);

        Task<int> Update(AppDiscotheque entity);

        Task<int> Delete(int id);
    }
}
