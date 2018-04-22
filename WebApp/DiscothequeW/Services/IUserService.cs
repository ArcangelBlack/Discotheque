using D.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscothequeW.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> GetById(int id);

        Task<bool> Save(User entity);

        Task<User> Update(User entity);

        Task<bool> Remove(User entity);
    }
}
