using D.Models.Repositories;

namespace D.Models.Models
{
    public class Rol : AuditableEntity, IEntityBase
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
