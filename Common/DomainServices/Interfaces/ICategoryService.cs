using DomainModels.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<AppDiscothequeCategorie>> GetAll();
    }
}
