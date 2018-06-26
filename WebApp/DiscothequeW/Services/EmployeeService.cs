using D.Models.Models;
using DiscothequeW.Services.Interfaces;

namespace DiscothequeW.Services
{
    public class EmployeeService : EntityBaseRepository<Employee>, IEmployeeService
    {
        public EmployeeService(ApplicationDbContext context)
            : base(context)
        { }
    }
}
