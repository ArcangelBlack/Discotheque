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
    
    public partial class AppDiscothequeDetail
    {
        public int Id { get; set; }
        public int DiscothequeCategoryId { get; set; }
        public int DiscothequeId { get; set; }
    
        public virtual AppDiscotheque AppDiscotheque { get; set; }
        public virtual AppDiscothequeCategorie AppDiscothequeCategorie { get; set; }
    }
}