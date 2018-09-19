using DomainModels.Model;
using DomainModels.Repositories.Interfaces;

namespace DomainServices.Interfaces
{
    public interface IMusicService : IAsyncRepository<AppMusic> { }
}
