using QLBX.FormChucNang;
using QLBX.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLBX.ViewModel
{
    class SapLichVM : BaseViewModel
    {
        #region Command
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand XuatCommand { get; set; }
        #endregion


        #region list
        //
        //public static string id;
        private ObservableCollection<CHUYENXE> _ChuyenXe;
        public ObservableCollection<CHUYENXE> ChuyenXe { get => _ChuyenXe; set { _ChuyenXe = value; OnPropertyChanged(); } }
        //so luong chuyen list
        private string _SoLuongChuyen;
        public string SoLuongChuyen { get => _SoLuongChuyen; set { _SoLuongChuyen = value; OnPropertyChanged(); } }
        //Xe list
        private ObservableCollection<XE> _XeList;
        public ObservableCollection<XE> XeList { get => _XeList; set { _XeList = value; OnPropertyChanged(); } }
        //chi tiết tuyến list
        private ObservableCollection<ChiTietTuyen> _ChiTietTuyens;
        public ObservableCollection<ChiTietTuyen> ChiTietTuyens { get => _ChiTietTuyens; set { _ChiTietTuyens = value; OnPropertyChanged(); } }
        //tài xế list
        private ObservableCollection<NHANVIENXE> _NhanVienXeList;
        public ObservableCollection<NHANVIENXE> NhanVienXeList { get => _NhanVienXeList; set { _NhanVienXeList = value; OnPropertyChanged(); } }
        //Tuyen xe list
        private ObservableCollection<TUYENXE> _TuyenXeList;
        public ObservableCollection<TUYENXE> TuyenXeList { get { return _TuyenXeList; } set { _TuyenXeList = value; } }


        #endregion
        //    public DateTime today = DateTime.Today;
        //public DateTime now = DateTime.Now;


        #region Input

        private DateTime _NGAYDI;
        public DateTime NGAYDI { get => _NGAYDI; set {_NGAYDI = value; OnPropertyChanged(); } }

        private DateTime _GIOBATDAU;
        public DateTime GIOBATDAU { get => _GIOBATDAU; set { _GIOBATDAU = value; OnPropertyChanged(); } }
        private DateTime _GIOKETTHUC;
        public DateTime GIOKETTHUC { get => _GIOKETTHUC; set { _GIOKETTHUC = value; OnPropertyChanged(); } }

        private DateTime _THOIGIANNGHI;
        public DateTime THOIGIANNGHI { get => _THOIGIANNGHI; set { _THOIGIANNGHI = value; OnPropertyChanged(); } }

        private int _SOCHUYEN;
        public int SOCHUYEN { get => _SOCHUYEN; set { _SOCHUYEN = value; OnPropertyChanged(); } }

        private int _THOIGIAN;
        public int THOIGIAN { get => _THOIGIAN; set { _THOIGIAN = value; OnPropertyChanged(); } }

        #endregion



        #region selectedItem

        //Selected item
        private ChiTietTuyen _SelectedItem;
        public ChiTietTuyen SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; if (SelectedItem != null)
                {
                    IDTUYEN = SelectedItem.IDTUYEN;
                    BENDI = SelectedItem.BENDI;
                    BENDEN = SelectedItem.BENDEN;
                    QUANDUONG = SelectedItem.QUANDUONG;
                    GIAVEMACDINH = SelectedItem.GIAVEMACDINH;
                    NGAYCAPNHAT = SelectedItem.NGAYCAPNHAT;
                    SOLUONGTAIXE = SelectedItem.SOLUONGTAIXE;
                    NHANVIENLIST = SelectedItem.NHANVIENLIST;
                    XELIST = SelectedItem.XELIST;

                    NGAYDI = SelectedItem.NGAYDI;
                    GIOBATDAU = SelectedItem.GIOBATDAU;
                    GIOKETTHUC = SelectedItem.GIOKETTHUC;
                    SOCHUYEN = SelectedItem.SOCHUYEN;
                    THOIGIAN = SelectedItem.X;
                };
            }
        }


        private int _IDTUYEN;
        public int IDTUYEN { get => _IDTUYEN; set { _IDTUYEN = value; OnPropertyChanged(); } }
        private string _BENDI;
        public string BENDI { get => _BENDI; set { _BENDI = value; OnPropertyChanged(); } }
        private string _BENDEN;
        public string BENDEN { get => _BENDEN; set { _BENDEN = value; OnPropertyChanged(); } }
        private int? _QUANDUONG;
        public int? QUANDUONG { get => _QUANDUONG; set { _QUANDUONG = value; OnPropertyChanged(); } }
        private float _GIAVEMACDINH;
        public float GIAVEMACDINH { get => _GIAVEMACDINH; set { _GIAVEMACDINH = value; OnPropertyChanged(); } }
        private DateTime _NGAYCAPNHAT;
        public DateTime NGAYCAPNHAT { get => _NGAYCAPNHAT; set { _NGAYCAPNHAT = value; OnPropertyChanged(); } }
        private int _SOLUONGTAIXE;
        public int SOLUONGTAIXE { get => _SOLUONGTAIXE; set { _SOLUONGTAIXE = value; OnPropertyChanged(); } }
        private int _SOLUONGXE;
        public int SOLUONGXE { get => _SOLUONGXE; set { _SOLUONGXE = value; OnPropertyChanged(); } }
        //private DateTime _THOIGIANDI;
        //public DateTime THOIGIANDI { get => _THOIGIANDI; set { _THOIGIANDI = value; OnPropertyChanged(); } }
        private ObservableCollection<NHANVIENXE> _NHANVIENLIST;
        public ObservableCollection<NHANVIENXE> NHANVIENLIST { get => _NHANVIENLIST; set { _NHANVIENLIST = value; OnPropertyChanged(); } }
        private ObservableCollection<XE> _XELIST;
        public ObservableCollection<XE> XELIST { get => _XELIST; set { _XELIST = value; OnPropertyChanged(); } }

        #endregion

        public SapLichVM()
        {
            
            DateTime now = DateTime.Now;
            TuyenXeList = new ObservableCollection<TUYENXE>(DataProvider.Ins.DB.TUYENXEs);
            var BenXeList = new ObservableCollection<BENXE>(DataProvider.Ins.DB.BENXEs);

            SelectedItem = new ChiTietTuyen();

            // create chi tiet tuyen
            #region chi tiet tuyen

            ChiTietTuyens = new ObservableCollection<ChiTietTuyen>();
            foreach (var tx in TuyenXeList)
            {
                ChiTietTuyen tam = new ChiTietTuyen();
                tam.IDTUYEN = tx.IDTUYEN;
                var x1 = BenXeList.Where(p => p.IDBEN == (int)tx.BENDI).Select(x => x.TENBEN).First();
                var x2 = BenXeList.Where(p => p.IDBEN == (int)tx.BENDEN).Select(x => x.TENBEN).First();
                if (tx.QUANDUONG != null)
                    tam.QUANDUONG = (int)tx.QUANDUONG;
                if (tx.GIAVEMATDINH != null)
                    tam.GIAVEMACDINH = (float)tx.GIAVEMATDINH;
                if (tx.NGAYCAPNHATGIA != null)
                    tam.NGAYCAPNHAT = (DateTime)tx.NGAYCAPNHATGIA;
                tam.BENDI = x1.ToString();
                tam.BENDEN = x2.ToString();
                tam.SOLUONGTAIXE = DataProvider.Ins.DB.NHANVIENXEs.Count(p => p.BENHIENTAI == tx.BENDI);
                tam.NHANVIENLIST = new ObservableCollection<NHANVIENXE>(DataProvider.Ins.DB.NHANVIENXEs.Where(p => p.BENHIENTAI == tx.BENDI));
                tam.XELIST = new ObservableCollection<XE>(DataProvider.Ins.DB.XEs.Where(p => p.BENHIENTAI == tx.BENDI));
                tam.SOLUONGXE = DataProvider.Ins.DB.XEs.Count(p => p.BENHIENTAI == tx.BENDI);
                if (tx.THOIGIANDI != null)
                    tam.THOIGIANDI = tx.THOIGIANDI;// ->time
                ChiTietTuyens.Add(tam);
            }
            #endregion



            #region Command
            //SelectionChanged Command
            SelectionChangedCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) => {
                NhanVienXeList = new ObservableCollection<NHANVIENXE>(DataProvider.Ins.DB.NHANVIENXEs.Where(l => l.IDNHANVIENXE == (DataProvider.Ins.DB.BENXEs.Where(q => q.TENBEN == BENDI).Select(x => x.IDBEN).FirstOrDefault())).ToList());
                //XeList = new ObservableCollection<XE>(DataProvider.Ins.DB.XEs.Where(b => b.BENHIENTAI == (DataProvider.Ins.DB.BENXEs.Where(q => q.TENBEN == BENDI).Select(x => x.IDBEN).FirstOrDefault())).ToList());
            });
            //Xuất chuyến command
            XuatCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) => {
                //string ngaydi = NGAYDI.ToShortDateString();
                //MessageBox.Show(ngaydi);
                //MessageBox.Show("thoi nghi short time: "+THOIGIANNGHI.ToString("HH:mm:ss")+"Gio bat dau - ket thuc:   "+GIOBATDAU.ToString("HH:mm:ss") +GIOKETTHUC.ToString("HH:mm:ss") +"");

                SapLichSubVM slvm = new SapLichSubVM();
                slvm.ChiTietTuyen = SelectedItem;
                SapLichSubForm slsf = new SapLichSubForm();
                slsf.DataContext = slvm;
                slsf.ShowDialog();
            });
            #endregion
        }
    }
}
