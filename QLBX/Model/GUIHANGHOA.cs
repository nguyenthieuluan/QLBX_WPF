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
    
    public partial class GUIHANGHOA
    {
        public int IDKHACHGUIHANG { get; set; }
        public string HOTEN { get; set; }
        public string DIACHI { get; set; }
        public string SDT { get; set; }
        public Nullable<int> IDCHUYEN { get; set; }
        public string TENHANG { get; set; }
        public Nullable<int> GIATIEN { get; set; }
    
        public virtual CHUYENXE CHUYENXE { get; set; }
        public virtual CHUYENXE CHUYENXE1 { get; set; }
    }
}
