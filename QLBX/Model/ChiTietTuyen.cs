using System;
using System.Collections.ObjectModel;

namespace QLBX.Model
{
    public class ChiTietTuyen
    {
        public int IDTUYEN { get; set; }
        public string BENDI { get; set; }
        public string BENDEN { get; set; }
        public float GIAVEMACDINH { get; set; }
        public DateTime NGAYCAPNHAT { get; set; }
        public int? QUANDUONG { get; set; }
        public int SOLUONGTAIXE { get; set; }
        public int SOLUONGXE { get; set; }
        public TimeSpan? THOIGIANDI { get; set; }
        public ObservableCollection<NHANVIENXE> NHANVIENLIST { get; set; }
        public ObservableCollection<XE> XELIST { get; set; }

        public DateTime NGAYDI { get; set; }
        public DateTime GIOBATDAU { get; set; }
        public DateTime GIOKETTHUC { get; set; }
        public int SOCHUYEN { get; set; }
        public int X { get; set; }
    }
}
