using DomainModels.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<AppEmployee>> GetAll();

        Task<AppEmployee> GetById(int id);

        Task<int> Create(AppEmployee entity);

        Task<int> Update(AppEmployee entity);

        Task<int> Delete(int id);
    }
}
