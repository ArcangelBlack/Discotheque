using DomainModels.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<AppCompanie>> GetAll();

        Task<AppCompanie> GetById(int id);

        Task<int> Create(AppCompanie entity);

        Task<int> Update(AppCompanie entity);

        Task<int> Delete(int id);
    }
}
