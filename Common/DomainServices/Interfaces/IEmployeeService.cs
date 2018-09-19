using DomainModels.Model;
using DomainModels.Repositories.Interfaces;

namespace DomainServices.Interfaces
{
    public interface IEmployeeService : IAsyncRepository<AppEmployee> { }
}
