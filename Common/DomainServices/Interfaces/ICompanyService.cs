﻿using DomainModels.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<AppCompanie>> GetAll();
    }
}
