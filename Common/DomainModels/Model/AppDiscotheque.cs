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
    
    public partial class AppDiscotheque
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AppDiscotheque()
        {
            this.AppDiscothequeDetails = new HashSet<AppDiscothequeDetail>();
            this.AppMusicDetails = new HashSet<AppMusicDetail>();
        }
    
        public int Id { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
        public string Cp { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public double Latitud { get; set; }
        public string Logo { get; set; }
        public double Longitud { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public string WebSite { get; set; }
    
        public virtual AppCompanie AppCompanie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppDiscothequeDetail> AppDiscothequeDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppMusicDetail> AppMusicDetails { get; set; }
    }
}