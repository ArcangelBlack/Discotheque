using DomainModels.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.Interfaces
{
    public interface ICalendarService 
    {
        Task<IEnumerable<AppCalendar>> GetAll();

        Task<AppCalendar> GetById(int id);

        Task<int> Create(AppCalendar dto);

        Task<int> Update(AppCalendar dto);

        Task<int> Delete(int id);
    }
}
