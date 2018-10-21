using DomainModels.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Interfaces
{
    public interface IUserService 
    {
        Task<IEnumerable<AppUser>> GetAll();

        Task<AppUser> GetById(int id);

        Task<int> Create(AppUser entity);

        Task<int> Update(AppUser entity);

        Task<int> Delete(int id);
    }
}
