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
    
    public partial class TieuChi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TieuChi()
        {
            this.ChiTietTieuChis = new HashSet<ChiTietTieuChi>();
        }
    
        public int MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
        public Nullable<int> DiemToiDa { get; set; }
        public Nullable<int> MaMucTieuChi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietTieuChi> ChiTietTieuChis { get; set; }
        public virtual MucTieuChi MucTieuChi { get; set; }
    }
}
