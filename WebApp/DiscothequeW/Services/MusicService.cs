using D.Models.Models;
using DiscothequeW.Services.Interfaces;

namespace DiscothequeW.Services
{
    public class MusicService : EntityBaseRepository<Music>, IMusicService
    {
        public MusicService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
