//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainModels.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppEmployee
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int RolId { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int Status { get; set; }
    
        public virtual AppRol AppRol { get; set; }
    }
}
