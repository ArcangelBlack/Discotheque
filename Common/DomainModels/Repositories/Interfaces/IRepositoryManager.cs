using System;
using System.Threading.Tasks;

namespace DomainModels.Repositories.Interfaces
{
    public interface IRepositoryManager : IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}
