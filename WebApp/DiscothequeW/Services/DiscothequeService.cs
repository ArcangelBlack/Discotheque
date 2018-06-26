using D.Models;
using D.Models.Models;
using DiscothequeW.Services.Interaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscothequeW.Services
{
    public class DiscothequeService : EntityBaseRepository<Discotheque>, IDiscothequeService
    {
        public DiscothequeService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
