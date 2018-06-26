using D.Models.Models;
using DiscothequeW.Services.Interfaces;

namespace DiscothequeW.Services
{
    public class UserService : EntityBaseRepository<User>, IUserService
    {
        public UserService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
