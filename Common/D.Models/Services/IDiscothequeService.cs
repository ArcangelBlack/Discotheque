using D.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace D.Models.Services
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
