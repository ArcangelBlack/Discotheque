using DomainModels.Model;
using DomainModels.Repositories.Interfaces;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DomainModels.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        #region fields

        private readonly DiscothequeDbEntities Context;

        #endregion

        #region Repositories

        public IAsyncRepository<AppCalendar> CalendarRepository { get; private set; }

        public IAsyncRepository<AppCompanie> CompanieRepository { get; private set; }

        public IAsyncRepository<AppDiscotheque> DiscothequeRepository { get; private set; }

        public IAsyncRepository<AppCategorie> CategoryRespository { get; private set; }

        public IAsyncRepository<AppDiscothequeDetail> DiscothequeDetailRespository { get; private set; }

        public IAsyncRepository<AppEmployee> EmployeeRespository { get; private set; }

        public IAsyncRepository<AppMusic> MusicRespository { get; private set; }

        public IAsyncRepository<AppMusicDetail> MusicDetailRespository { get; private set; }

        public IAsyncRepository<AppRol> RolRespository { get; private set; }

        public IAsyncRepository<AppUser> UserRespository { get; private set; }

        #endregion

        #region Constructor

        public RepositoryManager(DbContext context)
        {
            this.Context = context as DiscothequeDbEntities;

            this.CalendarRepository = new AsyncRespository<AppCalendar>(this.Context);
            this.CompanieRepository = new AsyncRespository<AppCompanie>(this.Context);
            this.DiscothequeRepository = new AsyncRespository<AppDiscotheque>(this.Context);
            this.CategoryRespository = new AsyncRespository<AppCategorie>(this.Context);
            this.DiscothequeDetailRespository = new AsyncRespository<AppDiscothequeDetail>(this.Context);
            this.EmployeeRespository = new AsyncRespository<AppEmployee>(this.Context);
            this.MusicRespository = new AsyncRespository<AppMusic>(this.Context);
            this.MusicDetailRespository = new AsyncRespository<AppMusicDetail>(this.Context);
            this.RolRespository = new AsyncRespository<AppRol>(this.Context);
            this.UserRespository = new AsyncRespository<AppUser>(this.Context);
        }

        #endregion


        public void Dispose()
        {
            this.Context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.Context.SaveChangesAsync();
        }
    }
}
