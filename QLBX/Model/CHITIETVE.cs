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
    
    public partial class CHITIETVE
    {
        public int IDCTVX { get; set; }
        public Nullable<int> SOGHE { get; set; }
        public Nullable<int> IDKHACH { get; set; }
        public Nullable<int> IDVE { get; set; }
    
        public virtual VEXE VEXE { get; set; }
        public virtual KHACHDIXE KHACHDIXE { get; set; }
    }
}
