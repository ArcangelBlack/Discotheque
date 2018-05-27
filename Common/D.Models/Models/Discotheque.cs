using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using D.Models.Repositories;

namespace D.Models.Models
{
    public class Discotheque : AuditableEntity, IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string Cp { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Logo { get; set; }

        [Required]
        public string WebSite { get; set; }

        public double Latitud { get; set; }

        public double Longitud { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public string Facebook { get; set; }

        public ICollection<DiscothequeDetail> DiscothequeDetails { get; set; }

        public Company Company { get; set; }
    }
}
