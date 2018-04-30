using D.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using D.Models.Repositories;

namespace D.Models.Models
{
    public class Company : AuditableEntity, IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdRol { get; set; }

        [Required]
        public string Ruc { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        public string Logo { get; set; }

        public ICollection<Discotheque> Discotheques { get; set; }

        public Rol Rol { get; set; }

    }
}
