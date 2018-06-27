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

    public partial class CHUYENXE : BaseViewModel
    {
        private int _iDCHUYEN;
        private int? _iDTUYEN;
        private string _bIENSO;
        private DateTime? _nGAYKHOIHANH;
        private TimeSpan? _tHOIGIANKHOIHANH;
        private DateTime? _tHOIGIANDEN;
        private decimal? _gIAVECHUYEN;
        private int? _iDNV1;
        private int? _iDNV2;
        private int? _iDNV3;
        private int? _iDNV4;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUYENXE()
        {
            this.GUIHANGHOAs = new HashSet<GUIHANGHOA>();
            this.GUIHANGHOAs1 = new HashSet<GUIHANGHOA>();
            this.VEXEs = new HashSet<VEXE>();
        }

        public int IDCHUYEN { get => _iDCHUYEN; set { _iDCHUYEN = value; OnPropertyChanged(); } }
        public Nullable<int> IDTUYEN { get => _iDTUYEN; set { _iDTUYEN = value; OnPropertyChanged(); } }
        public string BIENSO { get => _bIENSO; set { _bIENSO = value; OnPropertyChanged(); } }
        public Nullable<System.DateTime> NGAYKHOIHANH { get => _nGAYKHOIHANH; set { _nGAYKHOIHANH = value; OnPropertyChanged(); } }
        public Nullable<System.TimeSpan> THOIGIANKHOIHANH { get => _tHOIGIANKHOIHANH; set { _tHOIGIANKHOIHANH = value; OnPropertyChanged(); } }
        public Nullable<System.DateTime> THOIGIANDEN { get => _tHOIGIANDEN; set { _tHOIGIANDEN = value; OnPropertyChanged(); } }
        public Nullable<decimal> GIAVECHUYEN { get => _gIAVECHUYEN; set { _gIAVECHUYEN = value; OnPropertyChanged(); } }
        public Nullable<int> IDNV1 { get => _iDNV1; set { _iDNV1 = value; OnPropertyChanged(); } }
        public Nullable<int> IDNV2 { get => _iDNV2; set => _iDNV2 = value; }
        public Nullable<int> IDNV3 { get => _iDNV3; set => _iDNV3 = value; }
        public Nullable<int> IDNV4 { get => _iDNV4; set => _iDNV4 = value; }

        public virtual GIOKHOIHANH GIOKHOIHANH { get; set; }
        public virtual NHANVIENXE NHANVIENXE { get; set; }
        public virtual NHANVIENXE NHANVIENXE1 { get; set; }
        public virtual NHANVIENXE NHANVIENXE2 { get; set; }
        public virtual NHANVIENXE NHANVIENXE3 { get; set; }
        public virtual TUYENXE TUYENXE { get; set; }
        public virtual XE XE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GUIHANGHOA> GUIHANGHOAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GUIHANGHOA> GUIHANGHOAs1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VEXE> VEXEs { get; set; }
    }
}