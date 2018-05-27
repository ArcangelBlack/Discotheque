using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using D.Models.Repositories;

namespace D.Models.Models
{
    public class Music : AuditableEntity,  IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }
        
        //public string CashierId { get; set; }

        //public ApplicationUser Cashier { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
        
        public ICollection<MusicDetail> OrderDetails { get; set; }
    }
}
