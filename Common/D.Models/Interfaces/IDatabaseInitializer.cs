using System.Threading.Tasks;

namespace D.Models.Interfaces
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
