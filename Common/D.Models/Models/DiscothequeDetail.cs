using D.Models.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D.Models.Models
{
    public class DiscothequeDetail: IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DiscothequeCategoryId { get; set; }

        public int DiscothequeId { get; set; }

        public Discotheque Discotheque { get; set; }

        public DiscothequeCategory DiscothequeCategory { get; set; }
    }
}
