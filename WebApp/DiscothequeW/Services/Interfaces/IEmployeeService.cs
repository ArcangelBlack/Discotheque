using D.Models.Models;
using D.Models.Repositories;

namespace DiscothequeW.Services.Interfaces
{
    public interface IEmployeeService : IEntityBaseRepository<Employee> { }
    //{
    //    Task<IEnumerable<Employee>> GetAll();

    //    Task<Employee> GetById(int Id);

    //    Task<bool> Save(Employee entity);

    //    Task<Employee> Update(Employee entity);

    //    Task<bool> Remove(Employee entity);
    //}
}
