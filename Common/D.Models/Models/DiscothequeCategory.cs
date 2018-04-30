using System.Collections.Generic;
using D.Models.Repositories;

namespace D.Models.Models
{
    public class DiscothequeCategory : AuditableEntity, IEntityBase
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
