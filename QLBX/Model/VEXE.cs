//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBX.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class VEXE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VEXE()
        {
            this.CHITIETVEs = new HashSet<CHITIETVE>();
        }
    
        public int IDVE { get; set; }
        public Nullable<int> IDCHUYEN { get; set; }
        public Nullable<decimal> TONGTIEN { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETVE> CHITIETVEs { get; set; }
        public virtual CHUYENXE CHUYENXE { get; set; }
    }
}