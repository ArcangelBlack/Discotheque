using D.Models.Repositories;

namespace D.Models.Models
{
    public class MusicDetail : AuditableEntity, IEntityBase
    {
        public int Id { get; set; }

        public decimal Discount { get; set; }

        public int IdDiscotheque { get; set; }

        public Discotheque Discotheque { get; set; }

        public int IdMusic { get; set; }

        public Music Music { get; set; }
    }
}
