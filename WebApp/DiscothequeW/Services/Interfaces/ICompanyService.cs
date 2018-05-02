﻿using D.Models;
using D.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscothequeW.Services.Interaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAll();

        Task<IEnumerable<Company>> GetAllByCategories(IEnumerable<int> categories);

        Task<Company> GetById(int Id);

        Task<bool> Save(Company entity);

        Task<Company> Update(Company entity);

        Task<bool> Remove(Company entity);
    }
}