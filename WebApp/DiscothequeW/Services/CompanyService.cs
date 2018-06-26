using D.Models.Models;
using DiscothequeW.Services.Interaces;

namespace DiscothequeW.Services
{
    public class CompanyService : EntityBaseRepository<Company>, ICompanyService
    {
        public CompanyService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
