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

    public partial class LOAIXE : BaseViewModel
    {
        private int _iDLOAI;
        private string _tENLOAI;
        private int? _sOCHONGOI;
        private double? _hESOGIAVE;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIXE()
        {
            this.XEs = new HashSet<XE>();
        }

        public int IDLOAI { get => _iDLOAI; set { _iDLOAI = value; OnPropertyChanged(); } }
        public string TENLOAI { get => _tENLOAI; set { _tENLOAI = value; OnPropertyChanged(); } }
        public Nullable<int> SOCHONGOI { get => _sOCHONGOI; set { _sOCHONGOI = value; OnPropertyChanged(); } }
        public Nullable<double> HESOGIAVE { get => _hESOGIAVE; set { _hESOGIAVE = value; OnPropertyChanged(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XE> XEs { get; set; }
    }
}
