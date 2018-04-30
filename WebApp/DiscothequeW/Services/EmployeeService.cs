using D.Models;
using D.Models.Models;
using D.Models.Repositories;
using DiscothequeW.Services.Interaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscothequeW.Services.Interfaces;

namespace DiscothequeW.Services
{
    //public class EmployeeService : IEmployeeService
    //{

    //}

    public class EmployeeService : EntityBaseRepository<Employee>, IEmployeeService
    {
        public EmployeeService(ApplicationDbContext context)
            : base(context)
        { }
    }
}
