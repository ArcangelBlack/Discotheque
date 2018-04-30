using D.Models.Repositories;

namespace D.Models.Models
{
    public class DiscothequeDetail: IEntityBase
    {
        public int Id { get; set; }

        public int IdDiscothequeCategory { get; set; }

        public int IdDiscotheque { get; set; }

        public Discotheque Discotheque { get; set; }

        public DiscothequeCategory DiscothequeCategory { get; set; }
    }
}
