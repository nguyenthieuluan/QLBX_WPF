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
    using QLBX.ViewModel;
    using System;
    using System.Collections.Generic;

    public partial class BENXE : BaseViewModel
    {
        private int _iDBEN;
        private string _tENBEN;
        private string _tINH;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BENXE()
        {
            this.TUYENXEs = new HashSet<TUYENXE>();
            this.TUYENXEs1 = new HashSet<TUYENXE>();
        }

        public int IDBEN { get => _iDBEN; set { _iDBEN = value; OnPropertyChanged(); } }
        public string TENBEN { get => _tENBEN; set { _tENBEN = value; OnPropertyChanged(); } }
        public string TINH { get => _tINH; set { _tINH = value; OnPropertyChanged(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUYENXE> TUYENXEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUYENXE> TUYENXEs1 { get; set; }
    }
}
