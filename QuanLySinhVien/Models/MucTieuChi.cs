//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLySinhVien.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MucTieuChi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MucTieuChi()
        {
            this.TieuChis = new HashSet<TieuChi>();
        }
    
        public int MaMucTieuChi { get; set; }
        public string TenMucTieuChi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TieuChi> TieuChis { get; set; }
    }
}
