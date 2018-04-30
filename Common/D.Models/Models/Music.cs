using System;
using System.Collections.Generic;
using System.Text;
using D.Models.Repositories;

namespace D.Models.Models
{
    public class Music : AuditableEntity,  IEntityBase
    {
        public int Id { get; set; }

        public string Description { get; set; }
        
        //public string CashierId { get; set; }

        //public ApplicationUser Cashier { get; set; }

        public int IdCustomer { get; set; }

        public User User { get; set; }
        
        public ICollection<MusicDetail> OrderDetails { get; set; }
    }
}
