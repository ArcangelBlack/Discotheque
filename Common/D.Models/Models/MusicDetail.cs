using D.Models.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D.Models.Models
{
    public class MusicDetail : AuditableEntity, IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Discount { get; set; }

        public int DiscothequeId { get; set; }
        
        public int MusicId { get; set; }

        public Music Music { get; set; }

        public Discotheque Discotheque { get; set; }
    }
}
