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
    
    public partial class USER
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string IDPermission { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
        public virtual PERMISSION PERMISSION { get; set; }
    }
}