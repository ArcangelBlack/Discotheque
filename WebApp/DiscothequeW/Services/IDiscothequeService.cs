﻿using D.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscothequeW.Services
{
    public interface IDiscothequeService
    {
        Task<IEnumerable<Discotheque>> GetAll();

        Task<IEnumerable<Discotheque>> GetAllByCompanyId(int companyId);

        Task<Discotheque> GetById(int Id);

        Task<bool> Save(Discotheque entity);

        Task<Discotheque> Update(Discotheque entity);

        Task<bool> Remove(Discotheque entity);
    }
}
