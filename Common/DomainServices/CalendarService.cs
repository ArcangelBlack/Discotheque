using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Model;
using DomainModels.Repositories;
using DomainServices.Interfaces;

namespace DomainServices
{
    public class CalendarService : ICalendarService
    {
        public async Task<IEnumerable<AppCalendar>> GetAll()
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.CalendarRepository.GetAll();
            }
        }

        public async Task<AppCalendar> GetById(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.CalendarRepository.GetById(id);
            }
        }

        public async Task<int> Update(AppCalendar entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.CalendarRepository.Update(entity);
            }
        }

        public async Task<int> Create(AppCalendar entity)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                return await rm.CalendarRepository.Add(entity);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var rm = new RepositoryManager(new DiscothequeDbEntities()))
            {
                var entity = await this.GetById(id);
                if (entity != null)
                {
                    return await rm.CalendarRepository.Delete(entity);
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
