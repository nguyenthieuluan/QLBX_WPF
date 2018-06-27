using QLBX.FormChucNang;
using QLBX.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Forms;

namespace QLBX.ViewModel
{
    public class TuyenXeVM:BaseViewModel
    {
        #region Command

        public ICommand AddCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
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
        //check list
        private ObservableCollection<bool> _CheckList;
        public ObservableCollection<bool> CheckList { get { return _CheckList; } set { _CheckList = value; } }
        //Tuyen xe list
        private ObservableCollection<TUYENXE> _TuyenXeList;
        public ObservableCollection<TUYENXE> TuyenXeList{ get { return _TuyenXeList; } set { _TuyenXeList = value; }}
        //Gio khoi hanh list
        private ObservableCollection<GIOKHOIHANH> _GioKhoiHanhList;
        public ObservableCollection<GIOKHOIHANH> GioKhoiHanhList{get { return _GioKhoiHanhList; } set { _GioKhoiHanhList = value; }}

        //Ben xe list
        private ObservableCollection<BENXE> _BenXeList;
        public ObservableCollection<BENXE> BenXeList { get { return _BenXeList; } set { _BenXeList = value; } }

        #endregion

        //Selected item
        #region Chi tiet tuyen

        private ChiTietTuyen _SelectedItem;
        public ChiTietTuyen SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; if (SelectedItem != null)
                {
                    IDTUYEN = SelectedItem.IDTUYEN;
                    //BENDI = SelectedItem.BENDI;
                    //BENDEN = SelectedItem.BENDEN;
                    QUANDUONG = SelectedItem.QUANDUONG;
                    //GIAVEMACDINH = SelectedItem.GIAVEMACDINH;
                    NGAYCAPNHAT = SelectedItem.NGAYCAPNHAT;
                    SOLUONGTAIXE = SelectedItem.SOLUONGTAIXE;
                    NHANVIENLIST = SelectedItem.NHANVIENLIST;
                    XELIST = SelectedItem.XELIST;
                };
            }
        }

        private BENXE _SelectedBenDi;
        public BENXE SelectedBenDi { get => _SelectedBenDi; set { _SelectedBenDi = value; OnPropertyChanged(); } }
        private BENXE _SelectedBenDen;
        public BENXE SelectedBenDen { get => _SelectedBenDen; set { _SelectedBenDen = value; OnPropertyChanged(); } }

        private int? _IDTUYEN;
        public int? IDTUYEN { get => _IDTUYEN; set { _IDTUYEN = value; OnPropertyChanged(); } }

        private int? _BENDI;
        public int? BENDI { get => _BENDI; set { _BENDI = value; OnPropertyChanged(); } }
        private int? _BENDEN;
        public int? BENDEN { get => _BENDEN; set { _BENDEN = value; OnPropertyChanged(); } }
        private int? _QUANDUONG;
        public int? QUANDUONG { get => _QUANDUONG; set { _QUANDUONG = value; OnPropertyChanged(); } }
        private decimal? _GIAVEMACDINH;
        public decimal? GIAVEMACDINH { get => _GIAVEMACDINH; set { _GIAVEMACDINH = value; OnPropertyChanged(); } }
        private DateTime? _NGAYCAPNHAT;
        public DateTime? NGAYCAPNHAT { get => _NGAYCAPNHAT; set { _NGAYCAPNHAT = value; OnPropertyChanged(); } }
        private int _SOLUONGTAIXE;
        public int SOLUONGTAIXE { get => _SOLUONGTAIXE; set { _SOLUONGTAIXE = value; OnPropertyChanged(); } }
        private int _SOLUONGXE;
        public int SOLUONGXE { get => _SOLUONGXE; set { _SOLUONGXE = value; OnPropertyChanged(); } }
        private TimeSpan? _THOIGIANDI;
        public TimeSpan? THOIGIANDI { get => _THOIGIANDI; set { _THOIGIANDI = value; OnPropertyChanged(); } }
        private ObservableCollection<NHANVIENXE> _NHANVIENLIST;
        public ObservableCollection<NHANVIENXE> NHANVIENLIST { get => _NHANVIENLIST; set { _NHANVIENLIST = value;OnPropertyChanged(); } }
        private ObservableCollection<XE> _XELIST;
        public ObservableCollection<XE> XELIST { get => _XELIST; set { _XELIST = value;OnPropertyChanged(); } }
        #endregion



        private TUYENXE _SelectedItem2;
        public TUYENXE SelectedItem2
        {
            get => _SelectedItem2; set
            {
                _SelectedItem2 = value; if (SelectedItem2 != null)
                {
                    IDTUYEN = SelectedItem2.IDTUYEN;
                    BENDI = SelectedItem2.BENDI;
                    BENDEN = SelectedItem2.BENDEN;
                    QUANDUONG = SelectedItem2.QUANDUONG;
                    GIAVEMACDINH = SelectedItem2.GIAVEMATDINH;
                    NGAYCAPNHAT = SelectedItem2.NGAYCAPNHATGIA;
                    SelectedBenDi = SelectedItem2.BENXE1;
                    SelectedBenDen = SelectedItem2.BENXE;
                };
            }
        }

        public TuyenXeVM()
        {
            TuyenXeList = new ObservableCollection<TUYENXE>(DataProvider.Ins.DB.TUYENXEs);
            BenXeList = new ObservableCollection<BENXE>(DataProvider.Ins.DB.BENXEs);

            SelectedItem = new ChiTietTuyen();

            // create chi tiet tuyen
            #region chi tiet tuyen

            ChiTietTuyens = new ObservableCollection<ChiTietTuyen>();
            foreach(var tx in TuyenXeList)
            {
                ChiTietTuyen tam = new ChiTietTuyen();
                tam.IDTUYEN = tx.IDTUYEN;
                
                var x1 = BenXeList.Where(p => p.IDBEN == (int)tx.BENDI).Select(x => x.TENBEN).FirstOrDefault();
                var x2 = BenXeList.Where(p => p.IDBEN == (int)tx.BENDEN).Select(x => x.TENBEN).FirstOrDefault();
                if(tx.QUANDUONG!=null)
                    tam.QUANDUONG = (int)tx.QUANDUONG;
                if(tx.GIAVEMATDINH!=null)
                    tam.GIAVEMACDINH = (float)tx.GIAVEMATDINH;
                if(tx.NGAYCAPNHATGIA!=null)
                    tam.NGAYCAPNHAT = (DateTime)tx.NGAYCAPNHATGIA;
                tam.BENDI = x1.ToString();
                tam.BENDEN = x2.ToString();
                tam.SOLUONGTAIXE = DataProvider.Ins.DB.NHANVIENXEs.Count(p=>p.BENHIENTAI==tx.BENDI);
                tam.NHANVIENLIST = new ObservableCollection<NHANVIENXE>(DataProvider.Ins.DB.NHANVIENXEs.Where(p => p.BENHIENTAI == tx.BENDI));
                tam.XELIST = new ObservableCollection<XE>(DataProvider.Ins.DB.XEs.Where(p => p.BENHIENTAI == tx.BENDI));
                tam.SOLUONGXE = DataProvider.Ins.DB.XEs.Count(p=>p.BENHIENTAI==tx.BENDI);
                if(tx.THOIGIANDI!=null)
                    tam.THOIGIANDI = tx.THOIGIANDI;// ->time
                ChiTietTuyens.Add(tam);
            }
            #endregion


            #region Command

            
            SelectionChangedCommand = new RelayCommand<System.Windows.Controls.ComboBox>((p) => { return true; }, (p) => {
                //NhanVienXeList = new ObservableCollection<NHANVIENXE>(DataProvider.Ins.DB.NHANVIENXEs.Where(l => l.IDNHANVIENXE == (DataProvider.Ins.DB.BENXEs.Where(q => q.TENBEN == BENDI).Select(x => x.IDBEN).FirstOrDefault())).ToList());
                //XeList = new ObservableCollection<XE>(DataProvider.Ins.DB.XEs.Where(b => b.BENHIENTAI == (DataProvider.Ins.DB.BENXEs.Where(q => q.TENBEN == BENDI).Select(x => x.IDBEN).FirstOrDefault())).ToList());
            });

            //command
            
            //Thêm command
            AddCommand = new RelayCommand<object>((p) =>{ return true; }, (p) =>{
                int i = 1;
                //DialogResult result = System.Windows.Forms.MessageBox.Show("Thêm tuyến: "+ SelectedBenDi.TENBEN + " - " + SelectedBenDen.TENBEN,"Confirm!", MessageBoxButtons.YesNo);
                    foreach (TUYENXE x in DataProvider.Ins.DB.TUYENXEs)
                    {
                        if (x.BENDI == SelectedBenDi.IDBEN && x.BENDEN == SelectedBenDen.IDBEN)
                        {
                            i = 0; break;
                        }
                        if(SelectedBenDi.IDBEN == SelectedBenDen.IDBEN)
                        {
                            i = -1; break;
                        }
                    }
                    if (i == 0)
                        System.Windows.MessageBox.Show("Tuyến đã tồn tại!");
                    else if (i == -1)
                        System.Windows.MessageBox.Show("Vui lòng chọn bến khác!");
                    else
                    {
                            var tx = new TUYENXE();
                            tx.BENDI = SelectedBenDi.IDBEN;
                            tx.BENDEN = SelectedBenDen.IDBEN;
                            tx.GIAVEMATDINH = (decimal)GIAVEMACDINH;
                            tx.NGAYCAPNHATGIA = NGAYCAPNHAT;
                            tx.QUANDUONG = QUANDUONG;
                            tx.THOIGIANDI = THOIGIANDI;
                            DataProvider.Ins.DB.TUYENXEs.Add(tx);
                            DataProvider.Ins.DB.SaveChanges();
                            TuyenXeList.Add(tx);
                    }
            });


            EditCommand = new RelayCommand<object>((p) =>{return true;}, (p) =>{
                try
                {
                    var tx = DataProvider.Ins.DB.TUYENXEs.Where(x => x.IDTUYEN == IDTUYEN).SingleOrDefault();
                    //tx.BENDI = SelectedBenDi.IDBEN;
                    //tx.BENDEN = SelectedBenDen.IDBEN;
                    tx.GIAVEMATDINH = (decimal)GIAVEMACDINH;
                    tx.NGAYCAPNHATGIA = NGAYCAPNHAT;
                    tx.QUANDUONG = QUANDUONG;
                    tx.THOIGIANDI = THOIGIANDI;
                    
                    DataProvider.Ins.DB.SaveChanges();
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Tuyến đã đã sử dụng, không thể sữa!");
                }
                
               
            });
            DeleteCommand = new RelayCommand<object>((p) =>{return true;}, (p) =>{
                try
                {
                    var tx = DataProvider.Ins.DB.TUYENXEs.Where(x => x.IDTUYEN == IDTUYEN).SingleOrDefault();

                    DataProvider.Ins.DB.TUYENXEs.Remove(tx);
                    DataProvider.Ins.DB.SaveChanges();
                    TuyenXeList.Remove(tx);
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Tuyến đã đã sử dụng, không thể xóa!");
                }
            });
            #endregion
        }
    }
}
