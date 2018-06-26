using D.Models.Models;
using DiscothequeW.Services.Interfaces;

namespace DiscothequeW.Services
{
    public class CategoryService : EntityBaseRepository<DiscothequeCategory>, ICategoryService
    {
        public CategoryService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
